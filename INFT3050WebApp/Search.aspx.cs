using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INFT3050WebApp
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.AccountLinkEnabled = false;
            Master.AccountLinkVisible = false;

            Master.LogoutLinkEnabled = false;
            Master.LogoutLinkVisible = false;
        }
    }
}