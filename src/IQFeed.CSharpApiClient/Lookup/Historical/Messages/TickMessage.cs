﻿using System;
using System.Globalization;
using IQFeed.CSharpApiClient.Extensions;

namespace IQFeed.CSharpApiClient.Lookup.Historical.Messages
{
    public abstract class TickMessage
    {
        public const string TickDateTimeFormat = "yyyy-MM-dd HH:mm:ss.ffffff";
    }

    public class TickMessage<T> : TickMessage, ITickMessage<T>
    {
        public TickMessage(DateTime timestamp, T last, int lastSize, int totalVolume, T bid, T ask, 
            long tickId, char basisForLast, int tradeMarketCenter, string tradeConditions, string requestId = null)
        {
            RequestId = requestId;
            Timestamp = timestamp;
            Last = last;
            LastSize = lastSize;
            TotalVolume = totalVolume;
            Bid = bid;
            Ask = ask;
            TickId = tickId;
            BasisForLast = basisForLast;
            TradeMarketCenter = tradeMarketCenter;
            TradeConditions = tradeConditions;
        }

        public string RequestId { get; }
        public DateTime Timestamp { get; }
        public T Last { get; }
        public int LastSize { get; }
        public int TotalVolume { get; }
        public T Bid { get; }
        public T Ask { get; }
        public long TickId { get; }
        public char BasisForLast { get; }
        public int TradeMarketCenter { get; }
        public string TradeConditions { get; }

        public static TickMessage<T> Parse(string message)
        {
            var values = message.SplitFeedMessage();

            return new TickMessage<T>(
                DateTime.ParseExact(values[0], TickDateTimeFormat, CultureInfo.InvariantCulture),
                (T)Convert.ChangeType(values[1], typeof(T), CultureInfo.InvariantCulture),
                int.Parse(values[2], CultureInfo.InvariantCulture),
                int.Parse(values[3], CultureInfo.InvariantCulture),
                (T)Convert.ChangeType(values[4], typeof(T), CultureInfo.InvariantCulture),
                (T)Convert.ChangeType(values[5], typeof(T), CultureInfo.InvariantCulture),
                long.Parse(values[6], CultureInfo.InvariantCulture),
                char.Parse(values[7]),
                int.Parse(values[8], CultureInfo.InvariantCulture),
                values[9]);
        }

        public static TickMessage<T> ParseWithRequestId(string message)
        {
            var values = message.SplitFeedMessage();
            var requestId = values[0];

            return new TickMessage<T>(
                DateTime.ParseExact(values[1], TickDateTimeFormat, CultureInfo.InvariantCulture),
                (T)Convert.ChangeType(values[2], typeof(T), CultureInfo.InvariantCulture),
                int.Parse(values[3], CultureInfo.InvariantCulture),
                int.Parse(values[4], CultureInfo.InvariantCulture),
                (T)Convert.ChangeType(values[5], typeof(T), CultureInfo.InvariantCulture),
                (T)Convert.ChangeType(values[6], typeof(T), CultureInfo.InvariantCulture),
                long.Parse(values[7], CultureInfo.InvariantCulture),
                char.Parse(values[8]),
                int.Parse(values[9], CultureInfo.InvariantCulture),
                values[10],
                requestId);
        }

        public override bool Equals(object obj)
        {
            return obj is TickMessage<T> message &&
                   RequestId == message.RequestId &&
                   Timestamp == message.Timestamp &&
                   Equals(Last, message.Last)  &&
                   LastSize == message.LastSize &&
                   TotalVolume == message.TotalVolume &&
                   Equals(Bid, message.Bid) &&
                   Equals(Ask, message.Ask) &&
                   TickId == message.TickId &&
                   BasisForLast == message.BasisForLast &&
                   TradeMarketCenter == message.TradeMarketCenter &&
                   TradeConditions == message.TradeConditions;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = hash * 29 + RequestId != null ? RequestId.GetHashCode() : 0;
                hash = hash * 29 + Timestamp.GetHashCode();
                hash = hash * 29 + Last.GetHashCode();
                hash = hash * 29 + LastSize.GetHashCode();
                hash = hash * 29 + TotalVolume.GetHashCode();
                hash = hash * 29 + Bid.GetHashCode();
                hash = hash * 29 + Ask.GetHashCode();
                hash = hash * 29 + TickId.GetHashCode();
                hash = hash * 29 + BasisForLast.GetHashCode();
                hash = hash * 29 + TradeMarketCenter.GetHashCode();
                hash = hash * 29 + TradeConditions.GetHashCode();
                return hash;
            }
        }
    }
}