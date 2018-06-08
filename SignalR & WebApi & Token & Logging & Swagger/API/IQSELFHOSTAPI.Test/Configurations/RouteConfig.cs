using IQSELFHOSTAPI.Test.Logs;
using System.Web.Http;

namespace IQSELFHOSTAPI.Test.Configurations
{
    class RouteConfig
    {
        public static void RegisterRoutes(HttpConfiguration route)
        {
            route.SuppressDefaultHostAuthentication();
            route.Filters.Add(new HostAuthenticationFilter(Microsoft.Owin.Security.OAuth.OAuthDefaults.AuthenticationType));

            route.MessageHandlers.Add(new CustomLogHandler()); //Logging

            route.MapHttpAttributeRoutes();

            route.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{action}/{id}",
            defaults: new { id = RouteParameter.Optional });
        }
    }
}