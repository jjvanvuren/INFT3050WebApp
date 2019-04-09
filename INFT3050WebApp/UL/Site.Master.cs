using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INFT3050WebApp
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //// Used to enable and disable loginLink
        //public bool LoginLinkVisible
        //{
        //    set { loginLink.Visible = value; }
        //}

        //public bool LoginLinkEnabled
        //{
        //    set { loginLink.Enabled = value; }
        //}

        //// Used to enable and disable accountLink
        //public bool AccountLinkVisible
        //{
        //    set { accountLink.Visible = value; }
        //}

        //public bool AccountLinkEnabled
        //{
        //    set { accountLink.Enabled = value; }
        //}

        //// Used to enable and disable logoutLink
        //public bool LogoutLinkVisible
        //{
        //    set { logoutLink.Visible = value; }
        //}

        //public bool LogoutLinkEnabled
        //{
        //    set { logoutLink.Enabled = value; }
        //}

        //// Used to enable and disable accountLink
        //public bool RegisterLinkVisible
        //{
        //    set { registerLink.Visible = value; }
        //}

        //public bool RegisterLinkEnabled
        //{
        //    set { registerLink.Enabled = value; }
        //}

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UL/Search.aspx");
        }
    }
}