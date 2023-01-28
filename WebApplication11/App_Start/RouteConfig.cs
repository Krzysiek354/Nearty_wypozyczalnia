using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication11
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
             name: "WypozyRoute",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Home", action = "Wypozy" }
         );

            routes.MapRoute(
       name: "WypozyczRoute",
       url: "{controller}/{action}/{id}",
       defaults: new { controller = "Home", action = "Wypozycz" }
   );

            routes.MapRoute(
      name: "ZwolnijRoute",
      url: "{controller}/{action}/{id}",
      defaults: new { controller = "Home", action = "Zwolnij" }
  );

            

            routes.MapRoute(
       name: "SerwisBaza",
       url: "{controller}/{action}/{id}",
       defaults: new { controller = "Home", action = "Serwis_baza" }
   );



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
