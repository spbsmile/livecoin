using Newtonsoft.Json;

namespace Livecoin.Models.Private
{
    public class HistoryTransaction
    {
        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("date")]
        public long Date { get; set; }

        [JsonProperty("external")]
        public string External { get; set; }

        [JsonProperty("fee")]
        public double Fee { get; set; }

        [JsonProperty("fixedCurrency")]
        public string FixedCurrency { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("login")]
        public object Login { get; set; }

        [JsonProperty("taxCurrency")]
        public string TaxCurrency { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("variableAmount")]
        public double? VariableAmount { get; set; }

        [JsonProperty("variableCurrency")]
        public string VariableCurrency { get; set; }
    }
}