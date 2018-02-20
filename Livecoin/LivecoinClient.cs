using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Livecoin
{
    public partial class LivecoinClient : BaseLivecoinClient 
    {
        private static HttpClient _httpClient;

        protected override HttpClient GetStaticHttpClient => _httpClient;

        public LivecoinClient(string privateKey, string publicKey)
        {
            ApiKey = string.IsNullOrEmpty(publicKey)
                ? throw new ArgumentNullException(nameof(ApiKey))
                : publicKey;
            PrivateKey = string.IsNullOrEmpty(privateKey)
                ? throw new ArgumentNullException(nameof(PrivateKey))
                : privateKey;

            if (_httpClient != null) return;
            _httpClient = CreateHttpClient();
            _httpClient.BaseAddress = new Uri("https://api.livecoin.net");
        }

        private void ClearHeaders()
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }
        
        private async Task<LivecoinResponse<T>> QueryPublicGet<T>(string requestUrl,
            Dictionary<string, string> args = null)
        {
            if (requestUrl == null) throw new ArgumentNullException(nameof(requestUrl));
            ClearHeaders();

            args = args ?? new Dictionary<string, string>();

            var urlEncodedArgs = UrlEncode(args);          

            return await GetAsync<T>($"{BaseAddress}{requestUrl}?{urlEncodedArgs}");
        }

        private async Task<LivecoinResponse<T>> QueryPrivateGet<T>(string requestUrl,
            Dictionary<string, string> args = null)
        {
            if (requestUrl == null) throw new ArgumentNullException(nameof(requestUrl));
            ClearHeaders();

            args = args ?? new Dictionary<string, string>();

            var urlEncodedArgs = UrlEncode(args);

            _httpClient.DefaultRequestHeaders.Add("API-Key", ApiKey);
            _httpClient.DefaultRequestHeaders.Add("Sign", HashHMAC(
                    PrivateKey,
                    HttpBuildQuery(urlEncodedArgs))
                .ToUpper());

            return await GetAsync<T>($"{BaseAddress}{requestUrl}?{urlEncodedArgs}");
        }

        private async Task<LivecoinResponse<T>> QueryPrivatePost<T>(string requestUrl,
            Dictionary<string, string> args = null)
        {
            if (requestUrl == null) throw new ArgumentNullException(nameof(requestUrl));
            ClearHeaders();

            args = args ?? new Dictionary<string, string>();

            var urlEncodedArgs = UrlEncode(args);
            var content = new StringContent(urlEncodedArgs, Encoding.UTF8, "application/x-www-form-urlencoded");

            _httpClient.DefaultRequestHeaders.Add("API-Key", ApiKey);
            _httpClient.DefaultRequestHeaders.Add("Sign", HashHMAC(
                    PrivateKey,
                    HttpBuildQuery(urlEncodedArgs))
                .ToUpper());

            return await PostAsync<T>($"{BaseAddress}{requestUrl}", content);
        }

        private static string UrlEncode(Dictionary<string, string> args) => string.Join(
            "&",
            args.Where(x => x.Value != null).Select(x => x.Key + "=" + x.Value)
        );
    }
}