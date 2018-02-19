using Newtonsoft.Json;

namespace Livecoin.Models.Private
{
    public class Trade
    {
        [JsonProperty("clientorderid")]
        public long Clientorderid { get; set; }

        [JsonProperty("commission")]
        public double Commission { get; set; }

        [JsonProperty("datetime")]
        public long Datetime { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("quantity")]
        public double Quantity { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}