﻿using System.Collections.Generic;
using System.Linq;

namespace IQFeed.CSharpApiClient.Lookup.Historical.Messages.Extensions
{
    public static class DailyWeeklyMonthlyMessageExtensions
    {
        public static IEnumerable<DailyWeeklyMonthlyMessage<double>> ToDouble(this IEnumerable<IDailyWeeklyMonthlyMessage<decimal>> messages)
        {
            return messages.Select(message => message.ToDouble());
        }

        public static IEnumerable<DailyWeeklyMonthlyMessage<float>> ToFloat(this IEnumerable<IDailyWeeklyMonthlyMessage<decimal>> messages)
        {
            return messages.Select(message => message.ToFloat());
        }

        public static IEnumerable<DailyWeeklyMonthlyMessage<decimal>> ToDecimal(this IEnumerable<IDailyWeeklyMonthlyMessage<double>> messages)
        {
            return messages.Select(message => message.ToDecimal());
        }

        public static IEnumerable<DailyWeeklyMonthlyMessage<float>> ToFloat(this IEnumerable<IDailyWeeklyMonthlyMessage<double>> messages)
        {
            return messages.Select(message => message.ToFloat());
        }

        public static IEnumerable<DailyWeeklyMonthlyMessage<decimal>> ToDecimal(this IEnumerable<IDailyWeeklyMonthlyMessage<float>> messages)
        {
            return messages.Select(message => message.ToDecimal());
        }

        public static IEnumerable<DailyWeeklyMonthlyMessage<double>> ToDouble(this IEnumerable<IDailyWeeklyMonthlyMessage<float>> messages)
        {
            return messages.Select(message => message.ToDouble());
        }

        public static DailyWeeklyMonthlyMessage<double> ToDouble(this IDailyWeeklyMonthlyMessage<decimal> message)
        {
            return new DailyWeeklyMonthlyMessage<double>(
                message.Timestamp,
                (double)message.High,
                (double)message.Low,
                (double)message.Open,
                (double)message.Close,
                message.PeriodVolume,
                message.OpenInterest,
                message.RequestId);
        }

        public static DailyWeeklyMonthlyMessage<float> ToFloat(this IDailyWeeklyMonthlyMessage<decimal> message)
        {
            return new DailyWeeklyMonthlyMessage<float>(
                message.Timestamp,
                (float)message.High,
                (float)message.Low,
                (float)message.Open,
                (float)message.Close,
                message.PeriodVolume,
                message.OpenInterest,
                message.RequestId);
        }

        public static DailyWeeklyMonthlyMessage<decimal> ToDecimal(this IDailyWeeklyMonthlyMessage<double> message)
        {
            return new DailyWeeklyMonthlyMessage<decimal>(
                message.Timestamp,
                (decimal)message.High,
                (decimal)message.Low,
                (decimal)message.Open,
                (decimal)message.Close,
                message.PeriodVolume,
                message.OpenInterest,
                message.RequestId);
        }

        public static DailyWeeklyMonthlyMessage<float> ToFloat(this IDailyWeeklyMonthlyMessage<double> message)
        {
            return new DailyWeeklyMonthlyMessage<float>(
                message.Timestamp,
                (float)message.High,
                (float)message.Low,
                (float)message.Open,
                (float)message.Close,
                message.PeriodVolume,
                message.OpenInterest,
                message.RequestId);
        }

        public static DailyWeeklyMonthlyMessage<decimal> ToDecimal(this IDailyWeeklyMonthlyMessage<float> message)
        {
            return new DailyWeeklyMonthlyMessage<decimal>(
                message.Timestamp,
                (decimal)message.High,
                (decimal)message.Low,
                (decimal)message.Open,
                (decimal)message.Close,
                message.PeriodVolume,
                message.OpenInterest,
                message.RequestId);
        }

        public static DailyWeeklyMonthlyMessage<double> ToDouble(this IDailyWeeklyMonthlyMessage<float> message)
        {
            return new DailyWeeklyMonthlyMessage<double>(
                message.Timestamp,
                (double)message.High,
                (double)message.Low,
                (double)message.Open,
                (double)message.Close,
                message.PeriodVolume,
                message.OpenInterest,
                message.RequestId);
        }
    }
}