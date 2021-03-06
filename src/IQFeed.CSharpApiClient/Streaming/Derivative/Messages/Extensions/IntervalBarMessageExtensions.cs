﻿using System.Collections.Generic;
using System.Linq;

namespace IQFeed.CSharpApiClient.Streaming.Derivative.Messages.Extensions
{
    public static class IntervalBarMessageExtensions
    {
        public static IEnumerable<IntervalBarMessage<double>> ToDouble(this IEnumerable<IIntervalBarMessage<decimal>> messages)
        {
            return messages.Select(message => message.ToDouble());
        }

        public static IEnumerable<IntervalBarMessage<float>> ToFloat(this IEnumerable<IIntervalBarMessage<decimal>> messages)
        {
            return messages.Select(message => message.ToFloat());
        }

        public static IEnumerable<IntervalBarMessage<decimal>> ToDecimal(this IEnumerable<IIntervalBarMessage<double>> messages)
        {
            return messages.Select(message => message.ToDecimal());
        }

        public static IEnumerable<IntervalBarMessage<float>> ToFloat(this IEnumerable<IIntervalBarMessage<double>> messages)
        {
            return messages.Select(message => message.ToFloat());
        }

        public static IEnumerable<IntervalBarMessage<decimal>> ToDecimal(this IEnumerable<IIntervalBarMessage<float>> messages)
        {
            return messages.Select(message => message.ToDecimal());
        }

        public static IEnumerable<IntervalBarMessage<double>> ToDouble(this IEnumerable<IIntervalBarMessage<float>> messages)
        {
            return messages.Select(message => message.ToDouble());
        }

        public static IntervalBarMessage<double> ToDouble(this IIntervalBarMessage<decimal> message)
        {
           return new IntervalBarMessage<double>(
               message.Type, 
               message.Symbol, 
               message.Timestamp,
               (double)message.Open,
               (double)message.High,
               (double)message.Low,
               (double)message.Last, 
               message.CummulativeVolume,
               message.IntervalVolume,
               message.NumberOfTrades,
               message.RequestId);
        }

        public static IntervalBarMessage<float> ToFloat(this IIntervalBarMessage<decimal> message)
        {
            return new IntervalBarMessage<float>(
                message.Type,
                message.Symbol,
                message.Timestamp,
                (float)message.Open,
                (float)message.High,
                (float)message.Low,
                (float)message.Last,
                message.CummulativeVolume,
                message.IntervalVolume,
                message.NumberOfTrades,
                message.RequestId);
        }

        public static IntervalBarMessage<decimal> ToDecimal(this IIntervalBarMessage<double> message)
        {
            return new IntervalBarMessage<decimal>(
                message.Type,
                message.Symbol,
                message.Timestamp,
                (decimal)message.Open,
                (decimal)message.High,
                (decimal)message.Low,
                (decimal)message.Last,
                message.CummulativeVolume,
                message.IntervalVolume,
                message.NumberOfTrades,
                message.RequestId);
        }

        public static IntervalBarMessage<float> ToFloat(this IIntervalBarMessage<double> message)
        {
            return new IntervalBarMessage<float>(
                message.Type,
                message.Symbol,
                message.Timestamp,
                (float)message.Open,
                (float)message.High,
                (float)message.Low,
                (float)message.Last,
                message.CummulativeVolume,
                message.IntervalVolume,
                message.NumberOfTrades,
                message.RequestId);
        }

        public static IntervalBarMessage<decimal> ToDecimal(this IIntervalBarMessage<float> message)
        {
            return new IntervalBarMessage<decimal>(
                message.Type,
                message.Symbol,
                message.Timestamp,
                (decimal)message.Open,
                (decimal)message.High,
                (decimal)message.Low,
                (decimal)message.Last,
                message.CummulativeVolume,
                message.IntervalVolume,
                message.NumberOfTrades,
                message.RequestId);
        }

        public static IntervalBarMessage<double> ToDouble(this IIntervalBarMessage<float> message)
        {
            return new IntervalBarMessage<double>(
                message.Type,
                message.Symbol,
                message.Timestamp,
                (double)message.Open,
                (double)message.High,
                (double)message.Low,
                (double)message.Last,
                message.CummulativeVolume,
                message.IntervalVolume,
                message.NumberOfTrades,
                message.RequestId);
        }
    }
}