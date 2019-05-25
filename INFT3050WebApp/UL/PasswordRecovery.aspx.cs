using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INFT3050WebApp.UL
{
    public partial class PasswordRecovery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Enable SSL
            if (!Request.IsSecureConnection)
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + "UL/PasswordRecovery.aspx";
                Response.Redirect(url);
            }
        }

        // Redirects to the Password Recovery Page
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UL/RecoveryEmailSent.aspx");
        }
    }
}