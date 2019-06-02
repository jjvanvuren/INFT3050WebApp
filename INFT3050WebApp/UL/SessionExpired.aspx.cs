using System;

namespace INFT3050WebApp.UL
{
    public partial class SessionExpired : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblExpiredMessage.Text = "Your session has timed out, please return to the login page.";
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UL/Login");
        }
    }
}