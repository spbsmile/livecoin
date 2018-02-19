using Newtonsoft.Json;

namespace Livecoin.Models.Private
{
    public class CancelLimit
    {
        [JsonProperty("cancelled")]
        public bool Cancelled { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }

        [JsonProperty("quantity")]
        public double Quantity { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("tradeQuantity")]
        public long TradeQuantity { get; set; }
    }
}