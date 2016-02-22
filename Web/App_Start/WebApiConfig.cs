using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Newtonsoft.Json.Serialization;

namespace web {


    public class WebApiConfig {

        public static void Register(HttpConfiguration config) {
            // Web API configuration and services

            // validate all api requests for antiforgery and cookie tokens
            //config.Filters.Add(new ValidateAntiForgeryTokenWebApi());

            // handle business driven and general exception
            //config.Filters.Add(new BusinessServicesExceptionFilterAttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();

            // There can be multiple exception loggers. (By default, no exception loggers are registered.)
            //config.Services.Add(typeof(IExceptionLogger), new NLogExceptionLogger());


            // return json camelCase
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }


            );
        }



    }
}