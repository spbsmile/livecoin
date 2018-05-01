using System;
using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace Livecoin.Tests
{
    public class LivecoinFixture : IDisposable
    {
        private const string ApiKey = "";

        private const string PrivateKey = "";

        public LivecoinFixture()
        {
            Client = new LivecoinClient(PrivateKey, ApiKey);
        }

        public LivecoinClient Client { get; }

        public void Dispose()
        {
            Client.Dispose();
        }
    }

    public partial class LivecoinClientTests : IClassFixture<LivecoinFixture>
    {
        private readonly LivecoinClient _client;

        //MinBtc
        private const decimal Volume = 0.0001m;
        private const decimal PriceForSell = 20000;
        private const decimal PriceForBuy = 3000;
        private const string Symbol = "BTC/USD";

        public LivecoinClientTests(ITestOutputHelper output, LivecoinFixture fixture)
        {
            _client = fixture.Client;
        }


        [DebuggerStepThrough]
        private void AssertNotDefault<T>(T value) => Assert.NotEqual(default(T), value);
    }
}
