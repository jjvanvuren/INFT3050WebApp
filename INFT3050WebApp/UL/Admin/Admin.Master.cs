using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INFT3050WebApp.UL.BackEnd
{
    public partial class BackEnd : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool ToolsVisible
        {
            set { AdminSites.Visible = value; }
        }

        public bool LogoutLinkVisible
        {
            set { logoutLink.Visible = value; }
        }

        public bool LogoutLinkEnabled
        {
            set { logoutLink.Enabled = value; }
        }

        protected void logoutLink_Click(object sender, EventArgs e)
        {
            Session.Clear();
        }
    }
}