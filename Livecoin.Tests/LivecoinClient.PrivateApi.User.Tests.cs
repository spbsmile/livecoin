using System;
using System.Globalization;
using System.Threading.Tasks;
using Xunit;

namespace Livecoin.Tests
{
    public partial class LivecoinClientTests
    {
        [Fact]
        public async Task GetBalance()
        {
            var res = await _client.GetBalance("BTC");
            AssertNotDefault(res.Result.Value);
            AssertNotDefault(res.Result.Type);
        }

        [Fact]
        public async Task GetBalances()
        {
            var res = await _client.GetBalances("BTC,USD");
            foreach (var item in res.Result)
            {
                AssertNotDefault(item.Currency);
            }
        }

        [Fact]
        public async Task GetOrderInfo()
        {
            var res = await _client.BuyLimit(
                Symbol,
                PriceForBuy,
                Volume);

            Assert.True(res.Result.Success);
            var orderInfo = await _client.GetOrderInfo(res.Result.OrderId.ToString());

            AssertNotDefault(orderInfo.Result.Status);
            AssertNotDefault(orderInfo.Result.Quantity);
            AssertNotDefault(orderInfo.Result.Price);
            AssertNotDefault(orderInfo.Result.CommissionRate);

            var res2 = await _client.CancelLimit(Symbol, res.Result.OrderId);
            Assert.True(res2.Result.Success);
        }

        [Fact]
        public async Task GetHistotySize()
        {
            try
            {
                var res = await _client.GetHistorySize(
                    ToUnixTimestamp(DateTime.Now.AddDays(-1)).ToString(CultureInfo.InvariantCulture),
                    ToUnixTimestamp(DateTime.Now).ToString(CultureInfo.InvariantCulture));
                Assert.True(true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                // fail bad request, I do not know why (
                Assert.True(false);
            }
        }

        private int ToUnixTimestamp(DateTime value)
        {
            return (Int32)(value.ToUniversalTime().Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        [Fact]
        public async Task GetTrades()
        {
            try
            {
                var res = await _client.GetTrades(Symbol);
                Assert.True(true);
            }
            catch (Exception e)
            {
                Assert.True(false);
            }
        }
    }
}