﻿using System.Collections.Generic;
using System.Linq;

namespace IQFeed.CSharpApiClient.Lookup.Historical.Messages.Extensions
{
    public static class IntervalMessageExtensions
    {
        public static IEnumerable<IntervalMessage<double>> ToDouble(this IEnumerable<IIntervalMessage<decimal>> messages)
        {
            return messages.Select(message => message.ToDouble());
        }

        public static IEnumerable<IntervalMessage<float>> ToFloat(this IEnumerable<IIntervalMessage<decimal>> messages)
        {
            return messages.Select(message => message.ToFloat());
        }

        public static IEnumerable<IntervalMessage<decimal>> ToDecimal(this IEnumerable<IIntervalMessage<double>> messages)
        {
            return messages.Select(message => message.ToDecimal());
        }

        public static IEnumerable<IntervalMessage<float>> ToFloat(this IEnumerable<IIntervalMessage<double>> messages)
        {
            return messages.Select(message => message.ToFloat());
        }

        public static IEnumerable<IntervalMessage<decimal>> ToDecimal(this IEnumerable<IIntervalMessage<float>> messages)
        {
            return messages.Select(message => message.ToDecimal());
        }

        public static IEnumerable<IntervalMessage<double>> ToDouble(this IEnumerable<IIntervalMessage<float>> messages)
        {
            return messages.Select(message => message.ToDouble());
        }

        public static IntervalMessage<double> ToDouble(this IIntervalMessage<decimal> message)
        {
            return new IntervalMessage<double>(
                message.Timestamp,
                (double)message.High,
                (double)message.Low,
                (double)message.Open,
                (double)message.Close,
                message.TotalVolume,
                message.PeriodVolume,
                message.NumberOfTrades,
                message.RequestId);
        }

        public static IntervalMessage<float> ToFloat(this IIntervalMessage<decimal> message)
        {
            return new IntervalMessage<float>(
                message.Timestamp,
                (float)message.High,
                (float)message.Low,
                (float)message.Open,
                (float)message.Close,
                message.TotalVolume,
                message.PeriodVolume,
                message.NumberOfTrades,
                message.RequestId);
        }

        public static IntervalMessage<decimal> ToDecimal(this IIntervalMessage<double> message)
        {
            return new IntervalMessage<decimal>(
                message.Timestamp,
                (decimal)message.High,
                (decimal)message.Low,
                (decimal)message.Open,
                (decimal)message.Close,
                message.TotalVolume,
                message.PeriodVolume,
                message.NumberOfTrades,
                message.RequestId);
        }

        public static IntervalMessage<float> ToFloat(this IIntervalMessage<double> message)
        {
            return new IntervalMessage<float>(
                message.Timestamp,
                (float)message.High,
                (float)message.Low,
                (float)message.Open,
                (float)message.Close,
                message.TotalVolume,
                message.PeriodVolume,
                message.NumberOfTrades,
                message.RequestId);
        }

        public static IntervalMessage<decimal> ToDecimal(this IIntervalMessage<float> message)
        {
            return new IntervalMessage<decimal>(
                message.Timestamp,
                (decimal)message.High,
                (decimal)message.Low,
                (decimal)message.Open,
                (decimal)message.Close,
                message.TotalVolume,
                message.PeriodVolume,
                message.NumberOfTrades,
                message.RequestId);
        }

        public static IntervalMessage<double> ToDouble(this IIntervalMessage<float> message)
        {
            return new IntervalMessage<double>(
                message.Timestamp,
                (double)message.High,
                (double)message.Low,
                (double)message.Open,
                (double)message.Close,
                message.TotalVolume,
                message.PeriodVolume,
                message.NumberOfTrades,
                message.RequestId);
        }
    }
}