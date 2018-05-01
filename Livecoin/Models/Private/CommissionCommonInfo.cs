using Newtonsoft.Json;

namespace Livecoin.Models.Private
{
    public class CommissionCommonInfo
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("commission")]
        public string Commission { get; set; }

        [JsonProperty("last30DaysAmountAsUSD")]
        public string Last30DaysAmountAsUsd { get; set; }
    }
}
