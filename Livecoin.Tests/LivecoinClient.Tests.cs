using System;
using System.Diagnostics;
using Xunit;
using Xunit.Abstractions;

namespace Livecoin.Tests
{
    public class LivecoinFixture : IDisposable
    {
        public const string ApiKey = "<INSERT_API_KEY>";

        public const string PrivateKey = "<INSERT_PRIVATE_KEY>";

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
        public const decimal Volume = 0.0001m;
        public const decimal PriceForSell = 20000;
        public const decimal PriceForBuy = 3000;
        public const string Symbol = "BTC/USD";

        public LivecoinClientTests(ITestOutputHelper output, LivecoinFixture fixture)
        {
            _client = fixture.Client;
        }


        [DebuggerStepThrough]
        private void AssertNotDefault<T>(T value) => Assert.NotEqual(default(T), value);
    }
}
