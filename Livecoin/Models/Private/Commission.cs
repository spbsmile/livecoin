using Newtonsoft.Json;

namespace Livecoin.Models.Private
{
    public class Commission
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("fee")]
        public string Fee { get; set; }
    }
}
