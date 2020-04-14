﻿using System;
using System.Linq;
using System.Threading.Tasks;
using IQFeed.CSharpApiClient.Common.Exceptions;
using IQFeed.CSharpApiClient.Lookup;
using IQFeed.CSharpApiClient.Lookup.Symbol;
using NUnit.Framework;

namespace IQFeed.CSharpApiClient.Tests.Integration.Lookup.Historical
{
    public class MarketSummaryFacadeTests
    {
        private const int TimeoutMs = 30000;
        private const SecurityType Security_Type = SecurityType.FOPTION;
        //private const int GroupId = 31; //DOW JONES
        private const int GroupId = 34; //CME
        private const string RequestId = "TEST";

        private LookupClient<double> _lookupClient;
        private int _groupId;

        public MarketSummaryFacadeTests()
        {
            IQFeedLauncher.Start();
        }

        [SetUp]
        public async Task SetUp()
        {
            _lookupClient = LookupClientFactory.CreateNew();
            _lookupClient.Connect();
            var groupIds = await _lookupClient.Symbol.GetListedMarketsAsync();
            _groupId = groupIds.First(g => g.ShortName == "CME").ListedMarketId;
        }

        [TearDown]
        public void TearDown()
        {
            _lookupClient.Disconnect();
        }

        [Test]
        public async Task Should_Return_MarketSummarykMessages_When_GetEndOfDaySummaryAsync()
        {
            var marketSummaryMessages = await _lookupClient.MarketSummary.GetEndOfDaySummaryAsync(Security_Type, GroupId, new DateTime(2020, 04, 06));
            Assert.Greater(marketSummaryMessages.Count(), 0);
        }

        [Test]
        public async Task Should_Return_MarketSummarykMessages_When_GetFundamentalSummaryAsync()
        {
            var marketSummaryMessages = await _lookupClient.MarketSummary.GetEndOfDaySummaryAsync(Security_Type, GroupId, new DateTime(2020, 04, 06));
            Assert.Greater(marketSummaryMessages.Count(), 0);
        }

        [Test]
        public async Task Should_Return_MarketSummarykMessages_When_Get5MinuteSummaryAsync()
        {
            var marketSummaryMessages = await _lookupClient.MarketSummary.Get5MinuteSnapshotSummaryAsync(Security_Type, _groupId);
            Assert.Greater(marketSummaryMessages.Count(), 0);
        }
    }
}