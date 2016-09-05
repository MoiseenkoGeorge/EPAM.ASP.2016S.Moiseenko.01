using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;

namespace Day1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional},
                namespaces: new []{ "Day1.Controllers"},
                constraints: new
                {
                    httpMethod = new HttpMethodConstraint("GET"),
                    id = new CompoundRouteConstraint(new IRouteConstraint[]
                    {
                        new MinLengthRouteConstraint(5),
                        new AlphaRouteConstraint(),
                        new CustomRouteConstraint()
                    })
                }
            );

            routes.MapRoute(
                name: "MyRoute",
                url: "Home/{action}/{id}/{*catchall}",
                defaults: new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Day1.AdditionalControllers" },
                constraints: new { httpMethod = new HttpMethodConstraint("POST") }
                );

        }
    }
}
