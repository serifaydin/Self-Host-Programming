using DatabaseInfo;
using IQSELFHOSTAPI.Admin.Entities.ViewModels;
using IQSELFHOSTAPI.Admin.Manager;
using IQSELFHOSTAPI.Helpers;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace IQSELFHOSTAPI.Authenticator
{
    public class EchoAuthAttribute : AuthorizeAttribute
    {
        public static ConnectionHelper connectionHelper = new ConnectionHelper { Servername = App.ServerName, Username = App.Username, Password = App.Password, Database = App.AdminDatabaseName };

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            Console.WriteLine("Kullanıcı girişi yapılmamış.");
            BusinessLayerResult<ErrorViewModel> errorModel = new BusinessLayerResult<ErrorViewModel>();
            errorModel.Result = false;
            errorModel.AddError(Helpers.Messages.ErrorMessageCode.UnAuthorized, "Kullanıcı girişi yapılmamış.");
            var json = JsonConvert.SerializeObject(errorModel);
            actionContext.Response = new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,

                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
                return false;

            var token = actionContext.Request.Headers.Authorization.Parameter;
            if (string.IsNullOrEmpty(token))
                return false;

            UserTokenProcess utp = UserTokenProcess.UserTokenProcessMultiton(connectionHelper);
            var serviceResult = utp.UserTokenFindFunction(token);
            if (serviceResult.Result)
            {
                var userToken = serviceResult.Objects.FirstOrDefault();
                if (userToken != null)
                {
                    return userToken.ExpireDate > DateTime.Now;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
