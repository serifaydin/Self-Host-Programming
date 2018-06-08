using DatabaseInfo;
using IQSELFHOSTAPI.Admin.Entities;
using IQSELFHOSTAPI.Admin.Entities.ViewModels;
using IQSELFHOSTAPI.Admin.Manager;
using IQSELFHOSTAPI.Admin.Service;
using IQSELFHOSTAPI.Helpers;
using IQSELFHOSTAPI.Logging;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IQSELFHOSTAPI.Authenticator
{
    public static class ContextHelper
    {
        public static void SetCustomError(this OAuthGrantResourceOwnerCredentialsContext context, string errorMessage)
        {
            var json = new BusinessLayerResult<ErrorViewModel>();
            json.AddError(Helpers.Messages.ErrorMessageCode.UnAuthorized, errorMessage);

            context.SetError(json.ToJsonString());
            //context.Response.Write(json.ToJsonString());
        }

        public static void SetCustomError(this OAuthValidateClientAuthenticationContext context, string errorMessage)
        {
            var json = new BusinessLayerResult<ErrorViewModel>();
            json.AddError(Helpers.Messages.ErrorMessageCode.UnAuthorized, errorMessage);

            context.SetError(json.ToJsonString());
            //context.Response.Write(json.ToJsonString());
        }

        public static string ToJsonString(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }

    internal class TokenLog
    {
        Helpers.EnumBase.ProjectNames _projectNames;
        Helpers.EnumBase.ApplicationType _applicationType;
        LoggingProcess _log;

        public TokenLog(Helpers.EnumBase.ProjectNames projectNames
            , Helpers.EnumBase.ApplicationType applicationType)
        {
            _projectNames = projectNames;
            _applicationType = applicationType;
            _log = new LoggingProcess(new ConnectionHelper { Servername = App.ServerName, Username = App.Username, Password = App.Password, Database = App.CompanyDatabaseName });
        }

        public async void Start(string function)
        {
            await _log.TransactionLogAdded(
                   function
                   , Helpers.Messages.ErrorMessageCode.Authorization
                   , _projectNames
                   , _applicationType
                   ,
                   DateTime.Now
                   , "İşlem Başladı...");
        }

        public async void WriteTransactionLog(string function, string message, Helpers.Messages.ErrorMessageCode errorMessageCode)
        {
            await _log.TransactionLogAdded(
                   function
                   , errorMessageCode
                   , _projectNames
                   , _applicationType
                   ,
                   DateTime.Now
                   , message);
        }

        public async void WriteApplicationLog(string function, string message, Helpers.Messages.ErrorMessageCode errorMessageCode)
        {
            await _log.ApplicationLogAdded(
                   function
                   , errorMessageCode
                   , _projectNames
                   , _applicationType
                   , DateTime.Now
                   , message
               );
        }

        public async void Finish(string function)
        {
            await _log.TransactionLogAdded(
                   function
                   , Helpers.Messages.ErrorMessageCode.Authorization
                   , _projectNames
                   , _applicationType
                   ,
                   DateTime.Now
                   , "İşlem Tamamlandı...");
        }

    }

    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        // TODO : Logging bazı şeyleri değiştirilmeli.
        TokenLog _Logging = new TokenLog(Helpers.EnumBase.ProjectNames.Other, Helpers.EnumBase.ApplicationType.Web);

        public static ConnectionHelper connectionHelper = new ConnectionHelper { Servername = App.ServerName, Username = App.Username, Password = App.Password, Database = App.AdminDatabaseName };

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string function = context.Request + " " + context.Request.Method;
            try
            {
                _Logging.Start(function);
                _Logging.WriteTransactionLog(function, "Login validation işlemi başlatıldı...", Helpers.Messages.ErrorMessageCode.Authorization);
                bool isSuccess = true;
                //string clientId = string.Empty;
                //string clientSecret = string.Empty;

                //if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
                //{
                //    context.TryGetFormCredentials(out clientId, out clientSecret);
                //}

                //if (context.ClientId == null)
                //{
                //    isSuccess = false;
                //    context.SetCustomError("Kullanıcının tanımlayıcı bilgileri eksik");
                //}
                //else
                //{

                var dictionary = new Dictionary<string, string>
                    {
                        {"appId",context.Parameters["AppID"]},{"companyId",context.Parameters["CompanyId"]}
                    };

                foreach (var item in dictionary)
                {
                    if (string.IsNullOrWhiteSpace(item.Value))
                    {
                        _Logging.WriteTransactionLog(function, string.Format("Parametre [{0}] bilgisi set edilmemiş.", item.Key), Helpers.Messages.ErrorMessageCode.UnAuthorized);
                        _Logging.WriteApplicationLog(function, string.Format("Parametre [{0}] bilgisi set edilmemiş.", item.Key), Helpers.Messages.ErrorMessageCode.UnAuthorized);

                        context.SetCustomError(string.Format("Parametre [{0}] bilgisi set edilmemiş.", item.Key));
                        isSuccess = false;
                    }
                }

                context.OwinContext.Set("as:clientAppID", dictionary["appId"]);
                context.OwinContext.Set("as:clientCompanyID", dictionary["companyId"]);

                if (isSuccess)
                    context.Validated();
                //}
                _Logging.WriteTransactionLog(function, "Login validation işlemi tamamlandı.", Helpers.Messages.ErrorMessageCode.Authorization);
            }
            catch (Exception ex)
            {
                _Logging.WriteApplicationLog(function, ex.Message, Helpers.Messages.ErrorMessageCode.TryCatchMessage);
                context.SetCustomError(ex.Message);
            }
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            string function = context.Request + " " + context.Request.Method;
            try
            {
                _Logging.WriteTransactionLog(function, "Token verme işlemi başladı...", Helpers.Messages.ErrorMessageCode.Authorization);

                var appId = context.OwinContext.Get<string>("as:clientAppID");
                var companyId = context.OwinContext.Get<string>("as:clientCompanyID");

                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

                #region Kullanıcı işlemleri
                UserProcess up = UserProcess.UserProcessMultiton(connectionHelper);
                CompanyUserProcess cup = CompanyUserProcess.CompanyUserProcessMultiton(connectionHelper);
                CompanyApplicationLicenseProcess calp = CompanyApplicationLicenseProcess.UserTokenProcessMultiton(connectionHelper);
                bool isSuccess = true;
                Users user = null;
                var licenseResult = calp.FindLicenseByCompanyApplicationFunction(Convert.ToInt32(companyId), Convert.ToInt32(appId));
                if (!licenseResult.Result || licenseResult.Object == null)
                {
                    isSuccess = false;
                    _Logging.WriteTransactionLog(function, "Şirketin uygulama lisans bilgilerine ulaşılamadı.", Helpers.Messages.ErrorMessageCode.UnAuthorized);
                    _Logging.WriteApplicationLog(function, "Şirketin uygulama lisans bilgilerine ulaşılamadı.", Helpers.Messages.ErrorMessageCode.Authorization);
                    context.SetCustomError("Şirketin uygulama lisans bilgilerine ulaşılamadı.");
                }
                else
                {
                    var license = Convert.ToInt32(licenseResult.Object.ApplicationLicenseSize.Decrypt());
                    user = up.UserFindFunction(context.UserName, context.Password).Object;
                    if (user == null)
                    {
                        _Logging.WriteTransactionLog(function, string.Format("Kullanıcı: {0} veya parola yanlış.", context.UserName), Helpers.Messages.ErrorMessageCode.UnAuthorized);
                        _Logging.WriteApplicationLog(function, string.Format("Kullanıcı: {0} veya parola yanlış.", context.UserName), Helpers.Messages.ErrorMessageCode.UnAuthorized);
                        context.SetCustomError("Kullanıcı adı veya parola yanlış.");
                        isSuccess = false; ;
                    }
                    else
                    {
                        var userInCompany = cup.CanUseToApplication(user.TabloID, Convert.ToInt32(appId), Convert.ToInt32(companyId));

                        if (!userInCompany.Result)
                        {
                            _Logging.WriteTransactionLog(function, string.Format("{0} kullanıcısının girmek istediği {1} id uygulamasına yetkisi yok.", context.UserName, companyId), Helpers.Messages.ErrorMessageCode.UnAuthorized);
                            _Logging.WriteApplicationLog(function, string.Format("{0} kullanıcısının girmek istediği {1} id uygulamasına yetkisi yok.", context.UserName, companyId), Helpers.Messages.ErrorMessageCode.UnAuthorized);

                            context.SetCustomError("Kullanıcının bu uygulama için yetkisi yok.");
                            isSuccess = false; ;
                        }
                        else
                        {
                            if (Constants.Dic.Count >= license)
                            {
                                _Logging.WriteTransactionLog(function, string.Format("{0} id uygulaması için kullanıcı sayısı dolmuş.", appId), Helpers.Messages.ErrorMessageCode.UnAuthorized);
                                _Logging.WriteApplicationLog(function, string.Format("{0} id uygulaması için kullanıcı sayısı dolmuş.", appId), Helpers.Messages.ErrorMessageCode.UnAuthorized);
                                context.SetCustomError("Aktif kulalnıcı sayısı dolmuş.");
                                isSuccess = false;
                            }
                        }
                    }
                }

                #endregion

                if (isSuccess)
                {
                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    identity.AddClaim(new Claim("UserID", user.TabloID.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                    identity.AddClaim(new Claim(ClaimTypes.Role, user.AuthorityGroup.AuthorityName));

                    var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {
                        "AppId",appId
                    },
                    {
                        "CompanyId",companyId
                    },
                    {
                        "Username", user.UserFullName
                    },
                    {
                        "UserId",user.TabloID.ToString()
                    }
                });
                    var ticket = new AuthenticationTicket(identity, props);
                    context.Validated(ticket);
                    context.Request.Context.Authentication.SignIn(identity);

                    _Logging.WriteTransactionLog(function, string.Format("[Kullanıcı:{0}] [Uygulama No:{1}] [Şirket No:{2}] => Giriş Başarılı.", user.UserFullName, appId, companyId), Helpers.Messages.ErrorMessageCode.Authorization);
                }

                _Logging.WriteTransactionLog(function, "Token verme işlemi tamamlandı.", Helpers.Messages.ErrorMessageCode.Authorization);
                _Logging.Finish(function);
            }
            catch (Exception ex)
            {
                _Logging.WriteApplicationLog(function, ex.Message, Helpers.Messages.ErrorMessageCode.TryCatchMessage);
                context.SetCustomError(ex.Message);
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
        {
            string function = context.Request + " " + context.Request.Method;
            #region token ı kaydetme işlemi.
            int userId = Convert.ToInt32(context.AdditionalResponseParameters["UserId"]);
            int appId = Convert.ToInt32(context.AdditionalResponseParameters["AppId"]);
            int companyId = Convert.ToInt32(context.AdditionalResponseParameters["CompanyId"]);

            UserToken dbToken = GetActiveTokenForUser(userId, appId, companyId);
            UserTokenProcess utp = UserTokenProcess.UserTokenProcessMultiton(connectionHelper);
            BusinessLayerResult<UserToken> result = new BusinessLayerResult<UserToken>();
            if (dbToken != null)
            {
                dbToken.AccessToken = context.AccessToken;
                dbToken.ExpireDate = DateTime.Now.AddDays(Constants.ExpireDays.Days);
                result = utp.UserTokenUpdateFunction(dbToken);
            }
            else
            {
                dbToken = new UserToken();
                dbToken.AccessToken = context.AccessToken;
                dbToken.Application = new Application { TabloID = appId };
                dbToken.User = new Users { TabloID = userId };
                dbToken.Company = new Companies { TabloID = companyId };
                dbToken.ExpireDate = DateTime.Now.AddDays(Constants.ExpireDays.Days);
                dbToken.IsActive = true;
                dbToken.CreatedOn = DateTime.Now;
                dbToken.ModifiedOn = DateTime.Now;
                result = utp.UserTokenInsertFunction(dbToken);
            }
            #endregion
            return base.TokenEndpointResponse(context);
        }

        /// <summary>
        /// Token alacak kullanıcının, daha önceden aldığı bir token var ise geri döndürür.
        /// </summary>
        /// <param name="userId">Kullanıcı id numarası.</param>
        /// <param name="appId">Uygulama id numarası.</param>
        /// <param name="companyId">Şirket id numarası.</param>
        /// <returns>Geriye UserToken modeli döner.</returns>
        private UserToken GetActiveTokenForUser(int userId, int appId, int companyId)
        {
            UserToken result = null;

            UserTokenService userTokenService = new UserTokenService(connectionHelper);
            var serviceResult = userTokenService.FindToken(userId, appId, companyId);


            if (serviceResult.Result)
            {
                result = serviceResult.Objects.FirstOrDefault();
            }


            return result;
        }
    }
}