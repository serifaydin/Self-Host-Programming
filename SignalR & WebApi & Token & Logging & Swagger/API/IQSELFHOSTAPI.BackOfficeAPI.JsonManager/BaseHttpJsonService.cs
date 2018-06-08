using IQSELFHOSTAPI.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IQSELFHOSTAPI.BackOfficeAPI.JsonManager
{
    public class BaseHttpJsonService<T>
    {
        public string Url = "http://localhost:8090/api/DashboardPanel/";
        public string Token { get; set; }

        protected async Task<HttpClient> GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            if (!string.IsNullOrWhiteSpace(Token))
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + Token);
            return client;
        }

        protected async Task<BusinessLayerResult<T>> InsertOrUpdateOrDeleteFunction(T model, string functionName)
        {
            HttpClient client = await GetClient();
            var responce = await client.PostAsync(Url + functionName, new StringContent(JsonConvert.SerializeObject(model),
               Encoding.UTF8, "application/json"));
            var mobileResult = await responce.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<BusinessLayerResult<T>>(mobileResult);
        }

        protected async Task<BusinessLayerResult<T>> InsertOrUpdateOrDeleteFunction(List<T> model, string functionName)
        {
            HttpClient client = await GetClient();
            var responce = await client.PostAsync(Url + functionName, new StringContent(JsonConvert.SerializeObject(model),
               Encoding.UTF8, "application/json"));
            var mobileResult = await responce.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BusinessLayerResult<T>>(mobileResult);
        }

        protected async Task<BusinessLayerResult<T>> SelectFunction(string functionName)
        {
            HttpClient client = await GetClient();
            var result = await client.GetStringAsync(Url + functionName);

            return JsonConvert.DeserializeObject<BusinessLayerResult<T>>(result);
        }
    }
}