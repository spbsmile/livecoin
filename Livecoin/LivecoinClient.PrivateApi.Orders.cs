using System.Collections.Generic;
using System.Threading.Tasks;
using Livecoin.Models.Private;

namespace Livecoin
{
    public partial class LivecoinClient
    {
        /// <summary>
        /// Open a buy order (limit) for particular currency pair.
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>        
        public async Task<LivecoinResponse<OrderResponse>> BuyLimit(string symbol, decimal price,
            decimal quantity)
        {
            return await QueryPrivatePost<OrderResponse>("exchange/buylimit",
                new Dictionary<string, string>
                {
                    {"currencyPair", symbol},
                    {"price", price.ToString(Culture)},
                    {"quantity", quantity.ToString(Culture)}
                });
        }

        /// <summary>
        /// Open a sell order (limit) for a specified currency pair.
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public async Task<LivecoinResponse<OrderResponse>> SellLimit(string symbol, decimal price, decimal quantity)
        {
            return await QueryPrivatePost<OrderResponse>("exchange/selllimit",
                new Dictionary<string, string>
                {
                    {"currencyPair", symbol},
                    {"price", price.ToString(Culture)},
                    {"quantity", quantity.ToString(Culture)}
                });
        }

        /// <summary>
        /// Open a buy order (market) of specified amount for particular currency pair.
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="quantity"> Количество</param>
        /// <returns></returns>        
        public async Task<LivecoinResponse<OrderResponse>> BuyMarket(string symbol, decimal quantity)
        {
            return await QueryPrivatePost<OrderResponse>("exchange/buymarket",
                new Dictionary<string, string>
                {
                    {"currencyPair", symbol},                    
                    {"quantity", quantity.ToString(Culture)}
                });
        }

        /// <summary>
        /// Open a sell order (market) for specified amount of selected currency pair.
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>        
        public async Task<LivecoinResponse<OrderResponse>> SellMarket(string symbol, decimal quantity)
        {
            return await QueryPrivatePost<OrderResponse>("exchange/sellmarket",
                new Dictionary<string, string>
                {
                    {"currencyPair", symbol},                    
                    {"quantity", quantity.ToString(Culture)}
                });
        }

        /// <summary>
        /// Cancel order
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>        
        public async Task<LivecoinResponse<CancelLimit>> CancelLimit(string symbol, long orderId)
        {
            return await QueryPrivatePost<CancelLimit>("exchange/cancellimit",
                new Dictionary<string, string>
                {
                    {"currencyPair", symbol},                    
                    {"orderId", orderId.ToString()}
                });
        }
    }
}