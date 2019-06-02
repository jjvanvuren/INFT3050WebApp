using System;

namespace INFT3050WebApp.UL
{
    public partial class E401 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string defaultString = "You are not authorized to access this page. Please contact customer support for details on this issue.";
            lblErrorText.Text = defaultString;
        }
    }
}