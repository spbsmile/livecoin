using Newtonsoft.Json;

namespace Livecoin.Models.Private
{
    public class ClientOrders
    {
        [JsonProperty("data")]
        public ClientOrdersData[] Data { get; set; }

        [JsonProperty("endRow")]
        public long EndRow { get; set; }

        [JsonProperty("startRow")]
        public long StartRow { get; set; }

        [JsonProperty("totalRows")]
        public long TotalRows { get; set; }
    }
}