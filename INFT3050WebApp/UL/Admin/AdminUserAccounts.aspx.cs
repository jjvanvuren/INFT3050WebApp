﻿using System;
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
            if (Session["UserSession"] == null)
            {
                Response.Redirect("~/UL/Admin/AdminLogin.aspx");
            }

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

        /*https://www.codeproject.com/Articles/53559/Accessing-a-DropDownList-inside-a-GridView */
        /*protected void GridView1_RowCommand(object sender, GridViewRowEventArgs e)
        {
            Control ctrl = e.Row.FindControl("DdlIsAdmin");
            if (ctrl != null)
            {
                DropDownList dd = ctrl as DropDownList;
            }
        }

        protected void ddlIsAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /* protected void ddlIsAdmin_SelectedIndexChanged(Object sender, EventArgs e)
         {

             DdlIsAdmin.SelectedIndex
         }*/
    }
}