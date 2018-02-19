using Newtonsoft.Json;

namespace Livecoin
{
    /// <summary>
    /// Response from Exchange API.
    /// </summary>
    /// <typeparam name="T">Type of result.</typeparam>
    public class ExchangeResponse<T>
    {
        /// <summary>
        /// Gets or sets errors of a request.
        /// </summary>
        [JsonProperty("error")]
        public string Errors { get; set; }

        /// <summary>
        /// Gets or sets the result of a request.
        /// </summary>
        public T Result { get; set; } // Nullable
    }
}