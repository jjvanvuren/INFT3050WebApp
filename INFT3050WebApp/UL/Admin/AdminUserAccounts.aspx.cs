using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INFT3050WebApp.UL.Admin
{
    public partial class AdminUserAccounts : System.Web.UI.Page
    {
        //On PreInit check session data to see if logged in if not send to AdminLogin.axpc
        void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["UserSession"] == null)
            {
               Response.Redirect("~/UL/Admin/AdminLogin.aspx");
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void UserManagement_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // When clicking the View button take the user to the matching book's page
            if (e.CommandName == "cmdView")
            {
                Response.Redirect("~/UL/Admin/AdminPurchaseHistory.aspx");
            }

        }
    }
}