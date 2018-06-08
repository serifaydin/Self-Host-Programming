using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Admin.Entities.ViewModels;
using IQSELFHOSTAPI.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IQSELFHOSTAPI.BackOfficeAPI.JsonManager
{
    public class AdminJsonService
    {
        public static string Token { get; set; }

        public AdminJsonService()
        {

        }

        //string Url = "http://31.207.87.99:8090/api/Admin/";

        string Url = "http://localhost:8090/api/Admin/";

        private async Task<HttpClient> GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            if (!string.IsNullOrWhiteSpace(Token))
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + Token);
            return client;
        }
        public async Task<BusinessLayerResult<Users>> UserJsonList()
        {
            HttpClient client = await GetClient();
            string oAuthToken = string.Empty;
            var result = await client.GetStringAsync(Url + "GetFullUsers");
            return JsonConvert.DeserializeObject<BusinessLayerResult<Users>>(result);
        }

        public async Task<BusinessLayerResult<AuthenticationViewModel>> Login(LoginViewModel model)
        {
            BusinessLayerResult<AuthenticationViewModel> result = new BusinessLayerResult<AuthenticationViewModel>();
            // Invoke the "token" OWIN service to perform the login: /api/token
            // Ugly hack: I use a server-side HTTP POST because I cannot directly invoke the service (it is deeply hidden in the OAuthAuthorizationServerHandler class)

            //var tokenServiceUrl = "http://31.207.87.99:8090/api/Token";
            var tokenServiceUrl = "http://localhost:8090/api/Token";

            using (var client = GetClient().Result)
            {
                var requestParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", model.username),
                new KeyValuePair<string, string>("password", model.password),
                new KeyValuePair<string,string>("AppId",model.AppID.ToString()),
                new KeyValuePair<string, string>("CompanyId",model.CompanyID.ToString())
            };
                var requestParamsFormUrlEncoded = new FormUrlEncodedContent(requestParams);
                var tokenServiceResponse = await client.PostAsync(tokenServiceUrl, requestParamsFormUrlEncoded);
                var responseString = await tokenServiceResponse.Content.ReadAsStringAsync();
                if (tokenServiceResponse.IsSuccessStatusCode)
                {
                    var authModel = JsonConvert.DeserializeObject<OAuthModel>(responseString);
                    result.Result = true;
                    result.Object = new AuthenticationViewModel { AuthenticationModel = authModel };
                }
                else
                {
                    var ErrorModel = JsonConvert.DeserializeObject<ErrorViewModel>(responseString);
                    var resultView = JsonConvert.DeserializeObject<BusinessLayerResult<ErrorViewModel>>(ErrorModel.error);
                    result.AddError(resultView.Errors[0].Code, resultView.Errors[0].Message);
                    result.Result = false;
                }
            }

            return result;
        }

        public async Task<BusinessLayerResult<object>> Logout()
        {
            return null;
        }

        public async Task<BusinessLayerResult<Companies>> CompanyJsonList()
        {
            HttpClient client = await GetClient();
            var result = await client.GetStringAsync(Url + "GetFullCompanies");
            return JsonConvert.DeserializeObject<BusinessLayerResult<Companies>>(result);
        }

        public async Task<BusinessLayerResult<AuthorityGroup>> AuthorityGroupJsonModel(int id)
        {
            HttpClient client = await GetClient();
            var result = await client.GetStringAsync(Url + "GetAuthorityModel/?id=" + id);
            return JsonConvert.DeserializeObject<BusinessLayerResult<AuthorityGroup>>(result);
        }

        public async Task<BusinessLayerResult<Companies>> CompanyJsonInsert(Companies model)
        {
            HttpClient client = await GetClient();
            var responce = await client.PostAsync(Url + "CompanyAdded", new StringContent(JsonConvert.SerializeObject(model),
               Encoding.UTF8, "application/json"));
            var mobileResult = await responce.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BusinessLayerResult<Companies>>(mobileResult);
            return result;
        }

        public async Task<BusinessLayerResult<Users>> UserJsonInsert(Users model)
        {
            HttpClient client = await GetClient();
            var responce = await client.PostAsync(Url + "UserAdded", new StringContent(JsonConvert.SerializeObject(model),
               Encoding.UTF8, "application/json"));
            var mobileResult = await responce.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BusinessLayerResult<Users>>(mobileResult);
            return result;
        }

        public async Task<BusinessLayerResult<Users>> UserReturnModelJsonInsert(Users model)
        {
            HttpClient client = await GetClient();
            var responce = await client.PostAsync(Url + "UserReturnModelAdded", new StringContent(JsonConvert.SerializeObject(model),
               Encoding.UTF8, "application/json"));
            var mobileResult = await responce.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BusinessLayerResult<Users>>(mobileResult);
            return result;
        }

        public async Task<BusinessLayerResult<AuthorityGroup>> AuthorityGroupJsonList()
        {
            HttpClient client = await GetClient();
            var result = await client.GetStringAsync(Url + "GetFullAuthorityGroup");
            return JsonConvert.DeserializeObject<BusinessLayerResult<AuthorityGroup>>(result);
        }

        public async Task<BusinessLayerResult<CompanyApplicationUser>> CompanyUserJsonInsert(CompanyApplicationUser model)
        {
            HttpClient client = await GetClient();
            var responce = await client.PostAsync(Url + "CompanyUserAdded", new StringContent(JsonConvert.SerializeObject(model),
               Encoding.UTF8, "application/json"));
            var mobileResult = await responce.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<BusinessLayerResult<CompanyApplicationUser>>(mobileResult);
            return result;
        }

        public async Task<BusinessLayerResult<Modules>> ModulesJsonList()
        {
            HttpClient client = await GetClient();
            var result = await client.GetStringAsync(Url + "GetFullModulesList");
            return JsonConvert.DeserializeObject<BusinessLayerResult<Modules>>(result);
        }
    }
}