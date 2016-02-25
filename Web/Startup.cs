using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Routing;
using Microsoft.Owin;
using Owin;
using Repository;
using web;
using Web.App_Start;

[assembly: OwinStartup(typeof(Web.Startup))]
namespace Web {


    public class Startup {

        public void Configuration(IAppBuilder app) {

            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            SimpleInjectorInitializer.Initialize();


            // trigger db initialization
            var context = new ContosoUniversityContext();
            var students = context.Students.ToList();
        }

    }
}