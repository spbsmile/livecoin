using Newtonsoft.Json;

namespace Livecoin.Models.Private
{
    public class OrderResponse
    {
        [JsonProperty("added")]
        public bool Added { get; set; }

        [JsonProperty("orderId")]
        public long OrderId { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}