using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OdeToFood.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //This line of code (route template) is saying that if you receive a request that matches this format, ignore it. 
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //This is the route template that is used most of the time.
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional } //This is the default values that will invoke if one or more parameters are missing in a url
            );
        }
    }
}
