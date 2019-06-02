using System;
using System.Configuration;

namespace INFT3050WebApp.UL
{
    public partial class SuccessfulPasswordRecovery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Enable SSL
            if (!Request.IsSecureConnection)
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + "UL/SuccessfulPasswordRecovery.aspx";
                Response.Redirect(url);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UL/Login.aspx");
        }
    }
}