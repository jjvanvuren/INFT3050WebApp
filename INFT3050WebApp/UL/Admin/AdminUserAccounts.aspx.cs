using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INFT3050WebApp.UL.Admin
{
    public partial class AdminUserAccounts : System.Web.UI.Page
    {
        void Page_PreInit(object sender, EventArgs e)
        {
            //if (Session["UserSession"] == null)
            //{
              //  Response.Redirect("~/UL/Admin/AdminLogin.aspx");
            //}

        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void GridBooks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "cmdView")
            {
                Response.Redirect("AdminPurchaseHistory.aspx?id=" + e.CommandArgument);
            }

        }

        protected void ItemManagment_RowUpdated(object sender,GridViewUpdatedEventArgs e)
        {

        }
    }
}