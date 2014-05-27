using System.Net.Http.Headers;
using System.Web.Http;

namespace WebApiToMvcRouting
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // default to json format when possible
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
