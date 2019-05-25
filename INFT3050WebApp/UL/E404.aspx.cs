using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INFT3050WebApp.UL
{
    public partial class E404 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string defaultString = "The page you are looking for does not exist. Please contact customer support for details on this issue.";
            lblErrorText.Text = defaultString;
        }
    }
}