using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INFT3050WebApp.BL;

namespace INFT3050WebApp.UL.BackEnd
{
    public partial class BackEndRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Hide and disable the "Logout" link and links to other pages from master
            Master.ToolsVisible = false;
            Master.LogoutLinkEnabled = false;
            Master.LogoutLinkVisible = false;
        }

        //If registration is valid, send user to AdminPortal.aspx and create a session for login.
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Session.Clear();

                UserSession currentUserSession = new UserSession()
                {
                    Email = tbxEmail.Text,
                    Name = "Joe Smith",
                    LoggedIn = true
                };

                Session["UserSession"] = currentUserSession;

                Response.Redirect("~/UL/Admin/AdminPortal.aspx");
            }
        }

        //On click handler for cancel button - Sends to AdminLogin.aspx
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UL/Admin/AdminLogin.aspx");
        }
    }
}