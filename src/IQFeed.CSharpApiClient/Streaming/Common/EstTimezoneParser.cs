using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace IQFeed.CSharpApiClient.Streaming.Common
{
    public static class EstTimezoneParser
    {
        private static TimeZoneInfo EstTimeZoneInfo;

        static EstTimezoneParser()
        {
            EstTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
        }

        public static DateTime ParseTimeWithZonedDate(string timeString, string timeStringFormat,
            DateTime? utcNowOverrideForTesting = null)
        {
            return ParseTimeWithZonedDate(timeString, timeStringFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.None, utcNowOverrideForTesting);
        }

        public static bool ParseTimeWithZonedDate(string timeString, string timeStringFormat,
            IFormatProvider cultureProvider, DateTimeStyles dateTimeStyles, out DateTime parsedZonedDateTime,
            DateTime? utcNowOverrideForTesting = null)
        {
            try
            {
                var output = ParseTimeWithZonedDate(timeString, timeStringFormat, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, utcNowOverrideForTesting);
                parsedZonedDateTime = output;
                return true;
            }
            catch (Exception exception)
            {

            }

            parsedZonedDateTime = DateTime.MinValue;
            return false;
        }

        public static DateTime ParseTimeWithZonedDate(string timeString, string timeStringFormat,
            IFormatProvider cultureProvider, DateTimeStyles dateTimeStyles, DateTime? utcNowOverrideForTesting = null)
        {
            var utcNow = utcNowOverrideForTesting ?? DateTime.UtcNow;
            var parsedTime = TimeSpan.ParseExact(timeString, timeStringFormat, cultureProvider);
            var zonedDate = utcNow.Add(EstTimeZoneInfo.GetUtcOffset(DateTime.UtcNow)).Date;
            var parsedTimeWithZoneDate = zonedDate.Add(parsedTime);
            return parsedTimeWithZoneDate;
        }
    }
}
