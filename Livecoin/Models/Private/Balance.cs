using Newtonsoft.Json;

namespace Livecoin.Models.Private
{
    public class Balance
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }
        
        [JsonProperty(PropertyName = "value")]
        public decimal Value { get; set; }
    }
}