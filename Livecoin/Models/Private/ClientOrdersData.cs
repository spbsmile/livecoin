using Newtonsoft.Json;

namespace Livecoin.Models.Private
{
    public class ClientOrdersData
    {
        [JsonProperty("commission")]
        public object Commission { get; set; }

        [JsonProperty("commissionRate")]
        public double CommissionRate { get; set; }

        [JsonProperty("currencyPair")]
        public string CurrencyPair { get; set; }

        [JsonProperty("goodUntilTime")]
        public long GoodUntilTime { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("issueTime")]
        public long IssueTime { get; set; }

        [JsonProperty("lastModificationTime")]
        public long LastModificationTime { get; set; }

        [JsonProperty("orderStatus")]
        public string OrderStatus { get; set; }

        [JsonProperty("price")]
        public object Price { get; set; }

        [JsonProperty("quantity")]
        public double Quantity { get; set; }

        [JsonProperty("remainingQuantity")]
        public long RemainingQuantity { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}