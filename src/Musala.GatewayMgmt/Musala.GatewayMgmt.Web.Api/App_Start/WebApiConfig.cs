using Musala.GatewayMgmt.Web.Api.Models;
using Newtonsoft.Json;
using System.Web.Http;

namespace Musala.GatewayMgmt.Web.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            var jsonFormmatter = new BrowserJsonFormatter();

            // To avoid the error: "Self referencing loop detected - Getting back data from WebApi to the browser". 
            jsonFormmatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            config.Formatters.Add(jsonFormmatter);
        }
    }
}
