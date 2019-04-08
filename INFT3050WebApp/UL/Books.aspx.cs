using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INFT3050WebApp.UL
{
    public partial class Books : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridBooks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Response.Redirect("Book.aspx?id=" + e.CommandArgument);
        }
    }
}