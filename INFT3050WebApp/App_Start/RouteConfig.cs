using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace INFT3050WebApp
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);

            //routes.EnableFriendlyUrls();

            //routes.MapPageRoute("", "Default", "~/UL/Default.aspx");
            //routes.MapPageRoute("", "Search", "~/UL/Search.aspx");
        }
    }
}