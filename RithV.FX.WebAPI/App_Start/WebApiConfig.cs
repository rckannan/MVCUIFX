using RithV.FX.WebAPI.Infra.Security;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace RithV.FX.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            //config.MapHttpAttributeRoutes();
            var myObject = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(BasicAuthenticationMessageHandler)) as BasicAuthenticationMessageHandler;
            //var myObject = System.Web.Mvc.DependencyResolver.Current.GetService(typeof(BasicAuthenticationMessageHandler)) as BasicAuthenticationMessageHandler;
            if (myObject != null)
            {
                myObject.InnerHandler = new HttpControllerDispatcher(config);

                //for authentication, no headers required.... this will not validate the handler.
                config.Routes.MapHttpRoute(
                    name: "Auth",
                    routeTemplate: "api/Auth",
                    defaults: new { controller = "Auth" },
                    constraints: null,
                    handler: null
                    );

                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional },
                    constraints: null,
                    handler: myObject
                    );
            }


            //config.Routes.MapHttpRoute(
            //    name: "act",
            //    routeTemplate: "cat/{controller}/{action}",
            //    defaults: new { Controller = "CategoryController" }
            //);
            //var cors = new EnableCorsAttribute("www.example.com", "accept, authorization, x-my-custom-header", "*", exposedHeaders: "X-Custom-Header");
            //config.EnableCors(cors);

            config.Formatters.JsonFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("frmt", "json", new MediaTypeHeaderValue("application/json")));

            config.Formatters.XmlFormatter.MediaTypeMappings.Add(new QueryStringMapping("frmt", "xml",
                new MediaTypeHeaderValue("application/xml")));

            config.Formatters.XmlFormatter.UseXmlSerializer = true;

            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new DateConverter());

            //config.Filters.Add(new ClaimsAuthorizeAttribute());

            config.MessageHandlers.Add(new CultureHandler());
        }
    }
}
