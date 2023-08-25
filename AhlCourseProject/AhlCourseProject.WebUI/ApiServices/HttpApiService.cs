using AhlCourseProject.WebUI.Areas.AdminPanel.Models.ApiTypes;
using Microsoft.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace AhlCourseProject.WebUI.ApiServices
{
    public class HttpApiService : IHttpApiService
    {
        private readonly IHttpClientFactory _httpclientfactory;
        public HttpApiService(IHttpClientFactory httpclientfactory) { _httpclientfactory = httpclientfactory; }

        private string uri = $"http://localhost:5046/api";

        public async Task<T> GetData<T>(string reqURI)
        {
            T response = default(T);

            var requestmessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(uri+reqURI),
                Headers =
                {
                    { HeaderNames.Accept, "application/json" }
                }
            };

            var client = _httpclientfactory.CreateClient();
            var responsemessages = await client.SendAsync(requestmessage);


            var jsonstingT = await responsemessages.Content.ReadAsStringAsync();
            var repemeobj = JsonSerializer.Deserialize<T>(jsonstingT, new JsonSerializerOptions
            { PropertyNameCaseInsensitive = true });

            response = repemeobj;
            return response;

        }

        public async Task<T> PostData<T>(string reqURI, string jsonData)
        {
            T response = default(T);

            var requestmessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(uri + reqURI),
                Headers =
                {
                    { HeaderNames.Accept, "application/json" }
                },
                Content = new StringContent(jsonData,Encoding.UTF8,"application/json")
            };

            var client = _httpclientfactory.CreateClient();
            var responsemessages = await client.SendAsync(requestmessage);


            var jsonstingT = await responsemessages.Content.ReadAsStringAsync();
            var repemeobj = JsonSerializer.Deserialize<T>(jsonstingT, new JsonSerializerOptions
            { PropertyNameCaseInsensitive = true });

            response = repemeobj;
            return response;
        }


        //-------------------------------------------------------------------------------------------------------------------------------------------

        public async Task<bool> DeleteData(string reqURI)
        {
            var requestmessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(uri + reqURI),
                Headers =
                {
                    { HeaderNames.Accept, "application/json" }
                },
            };

            var client = _httpclientfactory.CreateClient();
            var responsemessages = await client.SendAsync(requestmessage);


            return responsemessages.IsSuccessStatusCode;

        }

        public async Task<bool> PutData(string reqURI, string jsonData)
        {

            var requestmessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri(uri + reqURI),
                Headers =
                {
                    { HeaderNames.Accept, "application/json" }
                },
                Content = new StringContent(jsonData, Encoding.UTF8, "application/json")
            };

            var client = _httpclientfactory.CreateClient();
            var responsemessages = await client.SendAsync(requestmessage);

            return responsemessages.IsSuccessStatusCode;


        }
    }
}
