using System;
using System.Configuration;
using INFT3050WebApp.BL;

namespace INFT3050WebApp.UL.Admin
{
    public partial class AdminVerified : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //Enable SSL
            if (!Request.IsSecureConnection)
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + "UL/Admin/AdminVerified.aspx";
                Response.Redirect(url);
            }

            string strEmail = Request.QueryString["email"];
            string strKey = Request.QueryString["key"];

            bool bVerified;

            try
            {
                // Verify the user with the DB
                User user = new User(strEmail);
                bVerified = user.Verify(strEmail, strKey);
            }
            catch (Exception exc)
            {
                throw exc;
            }

            if (bVerified)
            {
                lblHeader.Text = "Success!";
                lblMessage.Text = "Your email has been successfully verified. Click on the button below to login.";
            }
            else
            {
                lblHeader.Text = "Not Successful";
                lblMessage.Text = "Email verification has failed.";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UL/Admin/AdminLogin.aspx");
        }
    }
}