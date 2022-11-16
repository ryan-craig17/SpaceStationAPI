using System.Collections.Specialized;
using System.Text;
using System.Text.Json;
using SpaceStationAPI.Interfaces;
using SpaceStationAPI.Models.Domain;

namespace SpaceStationAPI.DataLayer
{
    public enum HttpVerb
    {
        Get,
        Post,
        Put,
        Delete
    };

    public class RestWorker : IRestWorker
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public async Task<T> CallService<T>(Uri wsURL, HttpVerb httpVerb = HttpVerb.Get, object data = null, NameValueCollection headerData = null) where T : BaseResponse
        {
            T result = default;
            StringContent _content = null;

            if (data != null)
                _content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

            var _method = VerbMethod(httpVerb);
            var request = new HttpRequestMessage() { RequestUri = wsURL, Method = _method, Content = _content };

            if (headerData != null)
            {
                foreach (string key in headerData)
                {
                    request.Headers.Add(key, headerData.Get(key));
                }
            }

            var response = await httpClient.SendAsync(request);

            if (response != null)
            {
                var resultData = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<T>(resultData);
                result.StatusCode = response.StatusCode;
            }

            return result;
        }

        private static HttpMethod VerbMethod(HttpVerb httpVerb) => httpVerb switch
        {
            HttpVerb.Get => HttpMethod.Get,
            HttpVerb.Post => HttpMethod.Post,
            HttpVerb.Put => HttpMethod.Put,
            HttpVerb.Delete => HttpMethod.Delete,
            _ => HttpMethod.Get,
        };
    }
}
