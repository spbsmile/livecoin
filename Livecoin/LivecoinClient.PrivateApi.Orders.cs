using System.Collections.Generic;
using System.Threading.Tasks;
using Livecoin.Models.Private;

namespace Livecoin
{
    public partial class LivecoinClient
    {
        /// <summary>
        /// Открыть ордер (лимитный) на покупку, определенной валюты.
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
        /// Открыть ордер (лимитный) на продажу определенной валюты. Доп.параметры аналогично покупки.
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
        /// Открыть ордер(рыночный) на покупку определенной валюты на заданное количество.
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
        /// Открыть ордер(рыночный) на продажу определенной валюты на заданное количество.
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
        /// Отменить ордер (лимитный).
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