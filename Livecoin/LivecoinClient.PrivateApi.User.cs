using System.Collections.Generic;
using System.Threading.Tasks;
using Livecoin.Models.Private;

namespace Livecoin
{
    public partial class LivecoinClient
    {
        /// <summary>
        /// Возвращает доступный баланс для выбранной валюты
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
        /// Возвращает массив с балансами пользователя. 
        /// Для каждой валюты существует 4 типа балансов: общий (total), доступные для торговли средства (available), средства в открытых ордерах 
        /// (trade), доступный для вывода (available_withdrawal)
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
        /// По конкретному клиенту получить информацию о его последних сделках, 
        /// результат может быть ограничен, соответствующими параметрами.
        /// </summary>
        /// <param name="currencyPair"></param>
        /// <param name="orderDesc">
        /// Порядок сортировки. Если true, то новые ордера будут первыми, если false, то старые ордера Значение по умолчанию: "true"       
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
                {"limit", limit.ToString()},
                {"offset", offset.ToString()}
            });
        }

        /// <summary>
        /// По конкретному клиенту и по конкретной паре валют получить полную информацию о его ордерах, 
        /// информация может быть ограничена либо только открытые либо только закрытые ордера.
        /// </summary>
        /// <param name="currencyPair"></param>
        /// <param name="openClosed"> 	Тип ордера (открытые, закрытые, все) Значение по умолчанию: ALL 
        /// Возможные значения: ALL OPEN CLOSED EXPIRED CANCELLED NOT_CANCELLED PARTIALLY</param>
        /// <param name="issuedFrom"> Начальная дата выборки </param>
        /// <param name="issuedTo"> Конечная дата выборки </param>
        /// <param name="startRow"> Порядковый номер первой записи</param>
        /// <param name="endRow"> Порядковый номер последней записи</param>
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
        /// Получить информацию об ордере по его ID
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
        /// Возвращает список транзакций пользователя
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
                    {"limit", limit.ToString()},
                    {"offset", offset.ToString()}
                });
        }

        /// <summary>
        /// Возвращает количество транзакций пользователя с заданными параметрами
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="types"> Типы транзакций (через запятую)
        /// Возможные значения: BUY SELL DEPOSIT WITHDRAWAL
        /// Пример: BUY,SELL DEPOSIT DEPOSIT,WITHDRAWAL</param>
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
    }
}