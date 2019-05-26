using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INFT3050WebApp.UL
{
    public partial class DefaultError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string errorMessage = Request.QueryString["error"];
            string errorSource = Request.QueryString["source"];
            string defaultString = "An error has occured with the web application. Please contact customer support for details on this issue.";

            lblErrorText.Text = defaultString;
            lblErrorDetails.Text = errorMessage;
            lblErrorSource.Text = errorSource;

        }
    }
}