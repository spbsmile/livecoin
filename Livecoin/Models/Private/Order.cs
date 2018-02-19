using Newtonsoft.Json;

namespace Livecoin.Models.Private
{
    public class Order
    {
        [JsonProperty("blocked")]
        public double Blocked { get; set; }

        [JsonProperty("blocked_remain")]
        public long BlockedRemain { get; set; }

        [JsonProperty("client_id")]
        public long ClientId { get; set; }

        [JsonProperty("commission_rate")]
        public double CommissionRate { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; } 

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("quantity")]
        public double Quantity { get; set; }

        [JsonProperty("remaining_quantity")]
        public double RemainingQuantity { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("trades")]
        public object Trades { get; set; }
    }
}