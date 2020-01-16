﻿using IQFeed.CSharpApiClient.Common;
using IQFeed.CSharpApiClient.Lookup.Chains;
using IQFeed.CSharpApiClient.Lookup.Common;
using IQFeed.CSharpApiClient.Lookup.Historical;
using IQFeed.CSharpApiClient.Lookup.News;
using IQFeed.CSharpApiClient.Lookup.Symbol;
using IQFeed.CSharpApiClient.Lookup.Symbol.ExpiredOptions;
using IQFeed.CSharpApiClient.Lookup.Symbol.MarketSymbols;

namespace IQFeed.CSharpApiClient.Lookup
{
    public static class LookupClientFactory
    {
        public static LookupClient<T> CreateNew<T>(
            string host,
            int port,
            int timeoutMs,
            int numberOfClients,
            int bufferSize)
        {
            // Common
            var requestFormatter = new RequestFormatter();
            var lookupDispatcher = new LookupDispatcher(host, port, bufferSize, IQFeedDefault.ProtocolVersion,
                numberOfClients, requestFormatter);
            var exceptionFactory = new ExceptionFactory();
            var rawMessageHandler = new RawMessageHandler(lookupDispatcher, exceptionFactory, timeoutMs);

            // Historical
            var historicalDataRequestFormatter = new HistoricalRequestFormatter();
            var historicalRawFace = new HistoricalRawFacade(historicalDataRequestFormatter, rawMessageHandler);
            var historicalFacade = new HistoricalFacade<T>(
                historicalDataRequestFormatter,
                lookupDispatcher,
                exceptionFactory,
                new HistoricalMessageHandler<T>(),
                historicalRawFace,
                timeoutMs
            );

            // News
            var newsFacade = new NewsFacade();

            // Symbol
            var symbolFacade = new SymbolFacade(
                new SymbolRequestFormatter(),
                lookupDispatcher,
                exceptionFactory,
                new SymbolMessageHandler(),
                new MarketSymbolDownloader(),
                new MarketSymbolReader(),
                new ExpiredOptionDownloader(),
                new ExpiredOptionReader(),
                timeoutMs);

            // Chains
            var chainsFacade = new ChainsFacade(new ChainsRequestFormatter(), new ChainsMessageHandler(),
                lookupDispatcher, exceptionFactory, timeoutMs);

            return new LookupClient<T>(lookupDispatcher, historicalFacade, newsFacade, symbolFacade, chainsFacade);
        }

        public static LookupClient<T> CreateNew<T>(int numberOfClients)
        {
            return CreateNew<T>(IQFeedDefault.Hostname, IQFeedDefault.LookupPort, LookupDefault.TimeoutMs,
                numberOfClients, LookupDefault.BufferSize);
        }


        public static LookupClient<decimal> CreateNew()
        {
            return CreateNew<decimal>(IQFeedDefault.Hostname, IQFeedDefault.LookupPort, LookupDefault.TimeoutMs, 1,
                LookupDefault.BufferSize);

        }

        public static LookupClient<T> CreateNew<T>()
        {
            return CreateNew<T>(IQFeedDefault.Hostname, IQFeedDefault.LookupPort, LookupDefault.TimeoutMs, 1, LookupDefault.BufferSize);

        }
    }
}