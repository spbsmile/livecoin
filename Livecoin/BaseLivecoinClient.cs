﻿using System;
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

        protected async Task<ExchangeResponse<TOut>> GetAsync<TOut>(string requestUri) =>
            await Http<object, TOut>(hc => hc.GetAsync(requestUri));

        protected async Task<ExchangeResponse<TOut>> PostAsync<TOut>(string requestUri, HttpContent content) =>
            await Http<object, TOut>(hc => hc.PostAsync(requestUri, content));

        private async Task<ExchangeResponse<TOut>> Http<TIn, TOut>(Func<HttpClient, Task<HttpResponseMessage>> func)
        {
            using (var response = await func(GetStaticHttpClient))
            {
                if (response == null) return default(ExchangeResponse<TOut>);
                var content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    throw new LivecoinApiException("There was a problem with a response from Livecoin.");
                }

                response.EnsureSuccessStatusCode();
                return new ExchangeResponse<TOut>
                {
                    Result = JsonConvert.DeserializeObject<TOut>(content, JsonSettings)
                };
            }
        }
    }
}