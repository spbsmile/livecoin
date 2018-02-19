using Newtonsoft.Json;

namespace Livecoin.Models.Public
{
    public class BidAsk
    {
        [JsonProperty(PropertyName = "last")]
        public double Last { get; set; }
        
        [JsonProperty(PropertyName = "high")]
        public double High { get; set; }
        
        [JsonProperty(PropertyName = "low")]
        public double Low { get; set; }
        
        [JsonProperty(PropertyName = "volume")]
        public double Volume { get; set; }
        
        [JsonProperty(PropertyName = "vwap")]
        public double Vwap { get; set; }
        
        [JsonProperty(PropertyName = "max_bid")]
        public double Maxbid { get; set; }
        
        [JsonProperty(PropertyName = "min_ask")]
        public double Minask { get; set; }
        
        [JsonProperty(PropertyName = "best_bid")]
        public decimal Bestbid { get; set; }
        
        [JsonProperty(PropertyName = "best_ask")]
        public decimal Bestask { get; set; }
    }
}