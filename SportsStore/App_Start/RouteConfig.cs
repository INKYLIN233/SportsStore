using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

//namespace SportsStore.App_Start
namespace SportsStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //定义新的URL方案
            routes.MapPageRoute(null, "list/{page}", "~/Pages/Listing.aspx");
            routes.MapPageRoute(null, "", "~/Pages/Listing.aspx");
            routes.MapPageRoute(null, "list", "~/Pages/Listing.aspx");
        }
    }
}