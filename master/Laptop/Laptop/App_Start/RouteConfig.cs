using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Laptop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(name: "SanPhamTheoNSX",
                url: "product/san-pham-{pathInfo}/{id}",
                defaults: new { controller = "Product", action = "ByManufacturer" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Show", action = "ShowNewProduct", id = UrlParameter.Optional }
            );
        }
    }
}
