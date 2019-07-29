using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LibraryBooksRegistration.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "AuthorCatalog",
                url: "Catalog/Authors",
                defaults: new { controller = "AuthorCatalog", action = "Index" }
            );
            
            routes.MapRoute(
                name: "BookCategoryCatalog",
                url: "Catalog/BookCategories",
                defaults: new { controller = "BookCategoryCatalog", action = "Index" }
            );

            routes.MapRoute(
                name: "BookCatalog",
                url: "Catalog/Books",
                defaults: new { controller = "BookCatalog", action = "Index" }
            );

            routes.MapRoute(
                name: "Statistics",
                url: "Statistics/BookCategories",
                defaults: new { controller = "Statistics", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "AuthorCatalog", action = "Index" }
            );
        }
    }
}
