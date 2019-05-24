using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INFT3050WebApp.UL.Admin
{
    public partial class AdminAddBookDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBookDetails_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UL/Admin/AdminRegister.aspx");
        }
    }
}