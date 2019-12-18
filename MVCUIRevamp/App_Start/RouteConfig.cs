using System.Web.Mvc;
using System.Web.Routing;

namespace RithV.FX
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "test1", id = UrlParameter.Optional }
            );
        }
    }
}
