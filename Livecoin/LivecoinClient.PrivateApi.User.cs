using System.Collections.Generic;
using System.Threading.Tasks;
using Livecoin.Models.Private;

namespace Livecoin
{
    public partial class LivecoinClient
    {
        /// <summary>
        /// Returns available balance for selected currency
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        public async Task<LivecoinResponse<Balance>> GetBalance(string currency)
        {
            return await QueryPrivateGet<Balance>("payment/balance", new Dictionary<string, string>
            {
                {"currency", currency}
            });
        }

        /// <summary>
        /// Returns an array of your balances. There are four types of balances for every currency: totaltotal, funds available for tradingavailable,
        /// funds in open orders trade , funds available for withdrawalavailable_withdrawal
        /// </summary>
        /// <param name="currencies"></param>
        /// <returns></returns>
        public async Task<LivecoinResponse<List<Balance>>> GetBalances(string currencies = null)
        {
            return await QueryPrivateGet<List<Balance>>("payment/balances", new Dictionary<string, string>
            {
                {"currency", currencies}
            });
        }

        /// <summary>
        /// Get information on your latest transactions. The return may be limited by the parameters below.
        /// </summary>
        /// <param name="currencyPair"></param>
        /// <param name="orderDesc">
        /// Sorting order. If true then new orders will be first, otherwise old orders will be first. Default value: "true"   
        /// </param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public async Task<LivecoinResponse<List<Trade>>> GetTrades(string currencyPair = null, string orderDesc = null,
            int? limit = null,
            int? offset = null)
        {
            return await QueryPrivateGet<List<Trade>>("exchange/trades", new Dictionary<string, string>
            {
                {"currencyPair", currencyPair},
                {"orderDesc", orderDesc},
                {"limit", limit?.ToString(Culture)},
                {"offset", offset?.ToString(Culture)}
            });
        }

        /// <summary>
        /// Get a detailed review of your orders for requested currency pair.
        /// You can optionally limit return of orders of a certain type (return only open or only closed orders) 
        /// </summary>
        /// <param name="currencyPair"></param>
        /// <param name="openClosed"> 	Order type.
        /// Possible values: ALL OPEN CLOSED EXPIRED CANCELLED NOT_CANCELLED PARTIALLY</param>
        /// <param name="issuedFrom"> Start date </param>
        /// <param name="issuedTo"> End date </param>
        /// <param name="startRow"> Sequence number of the first record</param>
        /// <param name="endRow"> Sequence number of the last record</param>
        /// <returns></returns>
        public async Task<LivecoinResponse<ClientOrders>> GetClientOrders(string currencyPair = null,
            string openClosed = null, string issuedFrom = null, string issuedTo = null,
            string startRow = null, string endRow = null)
        {
            return await QueryPrivateGet<ClientOrders>("exchange/client_orders", new Dictionary<string, string>
            {
                {"currencyPair", currencyPair},
                {"openClosed", openClosed},
                {"issuedFrom", issuedFrom},
                {"issuedTo", issuedTo},
                {"startRow", startRow},
                {"endRow", endRow}
            });
        }

        /// <summary>
        /// Get the order information by its ID.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<LivecoinResponse<Order>> GetOrderInfo(string orderId)
        {
            return await QueryPrivateGet<Order>("exchange/order", new Dictionary<string, string>
            {
                {"orderId", orderId}
            });
        }

        /// <summary>
        /// Returns a list of your transactions
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="types"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>        
        public async Task<LivecoinResponse<HistoryTransaction>> GetHistoryTransactions(string start, string end,
            string types = null, int? limit = null, int? offset = null)
        {
            return await QueryPrivateGet<HistoryTransaction>("payment/history/transactions",
                new Dictionary<string, string>
                {
                    {"start", start},
                    {"end", end},
                    {"types", types},
                    {"limit", limit?.ToString(Culture)},
                    {"offset", offset?.ToString(Culture)}
                });
        }

        /// <summary>
        /// Returns the number of transactions with pre-defined parameters
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="types"> Transaction types (comma- separated list)
        /// Possible values: BUY SELL DEPOSIT WITHDRAWAL</param>
        /// <returns></returns>
        public async Task<LivecoinResponse<int>> GetHistorySize(string start, string end, string types = null)
        {
            return await QueryPrivateGet<int>("payment/history/size",
                new Dictionary<string, string>
                {
                    {"start", start},
                    {"end", end},
                    {"types", types}
                });
        }

        /// <summary>
        /// Returns actual trading fee for customer
        /// </summary>
        /// <returns></returns>
        public async Task<LivecoinResponse<Commission>> GetCommission()
        {
            return await QueryPrivateGet<Commission>("exchange/commission",
                new Dictionary<string, string>());
        }

        /// <summary>
        /// Returns actual trading fee and volume for the last 30 days in USD
        /// </summary>
        /// <returns></returns>
        public async Task<LivecoinResponse<CommissionCommonInfo>> GetCommissionCommonInfo()
        {
            return await QueryPrivateGet<CommissionCommonInfo>("exchange/commissionCommonInfo",
                new Dictionary<string, string>());
        }
    }
}