using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;
using System.Diagnostics;

namespace INFT3050WebApp
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();

            if (exc is HttpUnhandledException)
            {
                // Pass the error on to the error page.
                Server.Transfer("~/UL/DefaultError.aspx?handler=Application_Error%20-%20Global.asax", true);
            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //RouteTable.Routes.EnableFriendlyUrls();
        }
    }
}