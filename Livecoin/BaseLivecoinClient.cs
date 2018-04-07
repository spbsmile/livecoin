using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Livecoin
{
    public abstract class BaseLivecoinClient
    {
        private static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver {NamingStrategy = new SnakeCaseNamingStrategy()}
        };

        protected HttpClient CreateHttpClient()
        {
            var hc = new HttpClient();
            hc.DefaultRequestHeaders.Accept.Clear();
            hc.DefaultRequestHeaders.Add("Accept", "application/json");
            return hc;
        }

        /// <summary>
        /// Gets the API key used for private requests.
        /// </summary>
        internal string ApiKey { get; set; }

        /// <summary>
        /// Gets the private key aka secret used to sign private requests.
        /// </summary>
        internal string PrivateKey { get; set; }

        protected abstract HttpClient GetStaticHttpClient { get; }

        /// <summary>
        /// Gets or sets the base address of Uniform Resource Identifier (URI) of the exchange API used
        /// </summary>
        protected Uri BaseAddress => GetStaticHttpClient.BaseAddress;

        protected async Task<LivecoinResponse<TOut>> GetAsync<TOut>(string requestUri) =>
            await Http<object, TOut>(hc => hc.GetAsync(requestUri));

        protected async Task<LivecoinResponse<TOut>> PostAsync<TOut>(string requestUri, HttpContent content) =>
            await Http<object, TOut>(hc => hc.PostAsync(requestUri, content));

        private async Task<LivecoinResponse<TOut>> Http<TIn, TOut>(Func<HttpClient, Task<HttpResponseMessage>> func)
        {
            using (var response = await func(GetStaticHttpClient))
            {
                if (response == null) return default(LivecoinResponse<TOut>);
                var content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    LivecoinMessageError messageError;
                    try
                    {
                        messageError = JsonConvert.DeserializeObject<LivecoinMessageError>(content, JsonSettings);

                    }
                    catch (Exception e)
                    {
                        throw new LivecoinApiException($"There was a problem with a response from Livecoin. ");
                    }

                    throw new LivecoinApiException("There was a problem with a response from Livecoin. " +
                                                   $"{Environment.NewLine} messageError: {messageError.ErrorMessage} " +
                                                   $"{Environment.NewLine} errorCode: {messageError.ErrorCode}");
                }

                response.EnsureSuccessStatusCode();
                return new LivecoinResponse<TOut>
                {
                    Result = JsonConvert.DeserializeObject<TOut>(content, JsonSettings)
                };
            }
        }
    }
}