﻿using System;
using IQFeed.CSharpApiClient.Socket;
using IQFeed.CSharpApiClient.Streaming.Level1.Handlers;

namespace IQFeed.CSharpApiClient.Streaming.Level1
{
    public static class Level1ClientFactory
    {
        public static Level1Client<T> CreateNew<T>(
            string host,
            int port,
            TimeSpan snapshotTimeout,
            ILevel1MessageHandler<T> level1MessageHandler)
        {
            var socketClient = new SocketClient(host, port);
            var level1RequestFormatter = new Level1RequestFormatter();

            return new Level1Client<T>(
                socketClient,
                level1RequestFormatter,
                level1MessageHandler,
                new Level1Snapshot<T>(socketClient, level1RequestFormatter, level1MessageHandler, snapshotTimeout),
                new DynamicFieldsetHandler()
            );
        }

        public static Level1Client<double> CreateNew()
        {
            return CreateNew(IQFeedDefault.Hostname, IQFeedDefault.Level1Port, Level1Default.SnapshotTimeout, new Level1MessageDoubleHandler());
        }

        public static Level1Client<double> CreateNew(string host, int port)
        {
            return CreateNew(host, port, Level1Default.SnapshotTimeout, new Level1MessageDoubleHandler());
        }

        public static Level1Client<double> CreateNew(string host, int port, TimeSpan snapshotTimeout)
        {
            return CreateNew(host, port, snapshotTimeout, new Level1MessageDoubleHandler());
        }
    }
}