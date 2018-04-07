using Newtonsoft.Json;

namespace Livecoin
{
    public class LivecoinMessageError
    {
        [JsonProperty("errorCode")]
        public long ErrorCode { get; set; }

        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }
    }
}