using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShopOnline5K
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
            name: "Add Cart",
            url: "add-to-cart",
            defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
            namespaces: new[] { "ShopOnline5K.Controllers" }
             );


            routes.MapRoute(
             name: "Search",
             url: "tim-kiem",
             defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional },
             namespaces: new[] { "ShopOnline5K.Controllers" }
              );

            routes.MapRoute(
            name: "Cart",
            url: "gio-hang",
            defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
            namespaces: new[] { "OnlineShop.Controllers" }
            );

            routes.MapRoute(
            name: "Product",
            url: "sanpham/{metatitle}-{id}",
            defaults: new { controller = "Product", action = "ListSPCategory", id = UrlParameter.Optional },
            namespaces: new[] { "ShopOnline5K.Controllers" }
             );

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
