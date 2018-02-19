using Newtonsoft.Json;

namespace Livecoin.Models.Public
{
    public class OrderBook
    {       
        // [0] - price [1] volume [2] timespan
        [JsonProperty("asks")]
        public string[][] Asks { get; set; }

        [JsonProperty("bids")]
        public string[][] Bids { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }       
}