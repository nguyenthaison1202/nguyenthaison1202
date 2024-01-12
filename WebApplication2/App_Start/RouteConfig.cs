using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("TrangChu", "{type}",
                new { controller = "Home", action = "Index" },
                new RouteValueDictionary
                    {
                        {"type","trang-chu" }
                    },
                new[] { "WebApplication2.Controllers" }
            );

            routes.MapRoute("Product", "{type}/{meta}",
                new {controller= "Product", action="Index",meta= UrlParameter.Optional},
                new RouteValueDictionary
                    {
                        {"type","san-pham" }
                    },
                new[] { "WebApplication2.Controllers" }
            );
            routes.MapRoute("Detail", "{type}/{meta}/{id}",
                new {controller= "Product", action="Detail",id= UrlParameter.Optional},
                new RouteValueDictionary
                    {
                        {"type","san-pham" }
                    },
                new[] { "WebApplication2.Controllers" }
            );
            routes.MapRoute("News", "{type}",
                new { controller = "News", action = "Index"},
                new RouteValueDictionary
                {
                    { "type", "tin-tuc" }
                },
                namespaces: new[] { "WebApplication2.Controllers" });

            routes.MapRoute("ChiTietTinTuc", "{type}/{id}",
                new {controller= "News", action="Detail", id = UrlParameter.Optional},
                new RouteValueDictionary
                    {
                        {"type","tin-tuc" }
                    },
                new[] { "WebApplication2.Controllers" }
            );

            routes.MapRoute("GioiThieu", "{type}",
                new { controller = "Home", action = "GioiThieu" },
                new RouteValueDictionary
                {
                    { "type", "gioi-thieu" }
                },
                namespaces: new[] { "WebApplication2.Controllers" });

            routes.MapRoute("LienHe", "{type}",
                new { controller = "Home", action = "LienHe" },
                new RouteValueDictionary
                {
                    { "type", "lien-he" }
                },
                namespaces: new[] { "WebApplication2.Controllers" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WebApplication2.Controllers" 
            });
        }
    }
}
