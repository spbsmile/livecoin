using System.Threading.Tasks;
using Xunit;

namespace Livecoin.Tests
{
    public partial class LivecoinClientTests
    {
        [Fact]
        public async Task BuyLimit()
        {
            var res = await _client.BuyLimit(
                Symbol,
                PriceForBuy,
                Volume);

            Assert.True(res.Result.Success);
            AssertNotDefault(res.Result.OrderId);
        }

        [Fact]
        public async Task SellLimit()
        {
            var res = await _client.SellLimit(
                Symbol,
                PriceForSell,
                Volume);

            Assert.True(res.Result.Success);
            AssertNotDefault(res.Result.OrderId);
        }

        [Fact]
        public async Task BuyMarket()
        {
            var res = await _client.BuyMarket(
                Symbol,
                Volume);

            Assert.True(res.Result.Success);
            AssertNotDefault(res.Result.OrderId);
        }

        [Fact]
        public async Task SellMarket()
        {
            var res = await _client.SellMarket(
                Symbol,
                Volume
            );

            Assert.True(res.Result.Success);
            AssertNotDefault(res.Result.OrderId);
        }

        [Fact]
        public async Task CancelLimit()
        {
            var res = await _client.BuyLimit(
                Symbol,
                PriceForBuy,
                Volume);

            Assert.True(res.Result.Success);
            var res2 = await _client.CancelLimit(Symbol, res.Result.OrderId);
            Assert.True(res2.Result.Success);
        }
    }
}