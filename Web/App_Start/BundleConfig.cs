using System.Web.Http.Results;
using System.Web.Optimization;
using Web.AngularTemplateBundling;

namespace Web.App_Start {

    public class BundleConfig {

        private const string VirtualPath = "~/app/";


        public static void RegisterBundles (BundleCollection bundles) {

            // styles
            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                "~/vendor/css/bootstrap.min.css",
                "~/css/styles.css"));


            // vendor library
            bundles.Add(new ScriptBundle("~/bundles/vendor").Include(

                // jquery and bootstrap
                "~/vendor/js/jquery-2.1.4.min.js",
                "~/vendor/js/bootstrap.min.js",

                // plugin
                "~/vendor/toastr/toastr.min.js",

                // angular core
                "~/vendor/js/angular.min.js",
                "~/vendor/js/angular-ui-router.min.js",
                "~/vendor/js/angular-animate.min.js",
                "~/vendor/js/angular-sanitize.min.js"));


            // App modules
            bundles.Add(new ScriptBundle("~/bundles/modules").IncludeDirectory("~/app", "*module.js", true));

            // App funtionality
            bundles.Add(new ScriptBundle("~/bundles/app").Include(

                // Blocks
                "~/app/blocks/route-helper-provider.js",
                //"~/app/blocks/logger-service.js",
                //"~/app/blocks/notify-service.js",

                // Core
                //"~/app/core/core-data-service.js",
                //"~/app/core/core-constants.js",
                //"~/app/core/core-config.js",
                //"~/app/core/core-http-interceptor.js",
                //"~/app/core/core-searchoptions-service.js",

                // home
                "~/app/home/home-route.js",
                "~/app/home/home-controller.js",

                // about
                "~/app/about/about-route.js",
                "~/app/about/about-controller.js",

                // students
                "~/app/students/students-route.js",
                "~/app/students/students-controller.js",

                // courses
                "~/app/courses/courses-route.js",
                "~/app/courses/courses-controller.js",

                // instructors
                "~/app/instructors/instructors-route.js",
                "~/app/instructors/instructors-controller.js",

                // departments
                "~/app/departments/departments-route.js",
                "~/app/departments/departments-controller.js"
                ));


            // bundle html into angular template cache
            bundles.Add(new AngularTemplateBundle("~/bundles/templates", "cu").IncludeDirectory(VirtualPath, "*.html", true));
        
        }

    }
}