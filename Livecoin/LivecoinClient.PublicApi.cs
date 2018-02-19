using System.Collections.Generic;
using System.Threading.Tasks;
using Livecoin.Models.Public;

namespace Livecoin
{
    public partial class LivecoinClient
    {
        public async Task<ExchangeResponse<BidAsk>> GetOrderBookTop(string symbol)
        {
            return await QueryPublicGet<BidAsk>("exchange/ticker",
                new Dictionary<string, string>
                {
                    {"currencyPair", symbol}
                });
        }

        public async Task<ExchangeResponse<OrderBook>> GetOrderBook(string symbol, int? depth)
        {
            return await QueryPublicGet<OrderBook>("exchange/order_book",
                new Dictionary<string, string>
                {
                    {"currencyPair", symbol},
                    {"depth", depth.ToString()}
                });
        }
    }
}