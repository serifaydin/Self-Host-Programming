using IQSELFHOSTAPI.Test;
using IQSELFHOSTAPI.Test.Configurations;
using IQSELFHOSTAPI.Test.Logs;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using Swashbuckle.Application;
using System;
using System.Web.Http;
using System.Xml.XPath;

[assembly: OwinStartup(typeof(Startup))]

namespace IQSELFHOSTAPI.Test
{
    public class Startup
    {
        #region old Api Config Codes
        //public void Configuration(IAppBuilder app)
        //{
        //    var config = new HttpConfiguration();

        //    config.Routes.MapHttpRoute(
        //        name: "DefaultApi",
        //        routeTemplate: "api/{controller}/{action}/{id}",
        //        defaults: new { id = RouteParameter.Optional });

        //    config.MapHttpAttributeRoutes();

        //    app.UseWebApi(config);
        //} 
        #endregion
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            RouteConfig.RegisterRoutes(config);
            Authenticator.Startup.ConfigureOAuth(app);
            app.UseCors(CorsOptions.AllowAll);

            app.Map("/signalr", map =>
            {
                GlobalHost.Configuration.ConnectionTimeout = TimeSpan.FromSeconds(30);
                GlobalHost.Configuration.DisconnectTimeout = new TimeSpan(0, 0, 6);
                GlobalHost.Configuration.KeepAlive = new TimeSpan(0, 0, 2);
                GlobalHost.Configuration.MaxIncomingWebSocketMessageSize = null;

                app.UseCors(CorsOptions.AllowAll);

                var hubConfig = new HubConfiguration
                {
                    EnableDetailedErrors = true,
                    EnableJSONP = true
                };

                map.RunSignalR(hubConfig);
            });

            app.UseWebApi(config);

            config.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "Swagger Test API");
                c.IncludeXmlComments(GetXmlCommentPath());
            }).EnableSwaggerUi();


        }

        private string GetXmlCommentPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory + @"IQSELFHOSTAPI.Test.xml";
        }
    }
}