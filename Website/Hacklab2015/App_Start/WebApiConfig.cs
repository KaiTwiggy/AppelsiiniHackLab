using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace Hacklab2015
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

			//var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
			//json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

			config.Routes.MapHttpRoute(
				name: "RelayApi",
				routeTemplate: "api/relay/",
				defaults: new { controller = "RelayApi", action = "RelayMessage" }
			);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
