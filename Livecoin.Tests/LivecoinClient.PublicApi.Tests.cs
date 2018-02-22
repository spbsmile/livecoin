using System.Threading.Tasks;
using Xunit;

namespace Livecoin.Tests
{
    public partial class LivecoinClientTests
    {
        [Fact]
        public async Task GetOrderBook()
        {
            var res = await _client.GetOrderBook(Symbol);
            AssertNotDefault(res.Result.Bids[0][0]);

            var res2 = await _client.GetOrderBook(Symbol, 1);
            Assert.Single(res2.Result.Bids);
        }

        [Fact]
        public async Task GetOrderBookTop()
        {
            var res = await _client.GetOrderBookTop(Symbol);
            AssertNotDefault(res.Result.Bestask);
        }
    }
}
