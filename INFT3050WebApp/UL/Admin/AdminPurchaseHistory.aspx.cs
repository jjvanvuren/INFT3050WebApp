﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INFT3050WebApp.BL;

namespace INFT3050WebApp.UL.Admin
{
    public partial class AdminPurchaseHistory : System.Web.UI.Page
    {
        //On PreInit check session data to see if logged in if not send to AdminLogin.axpc
        void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["UserSession"] == null)
            {
                Response.Redirect("~/UL/Admin/AdminLogin.aspx");
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Enable SSL
            if (!Request.IsSecureConnection)
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + "UL/Admin/AdminPurchaseHistory.aspx";
                Response.Redirect(url);
            }

            string UserID = Request.QueryString["Id"];

            // Display the users purchase history based on the Id passed by the query string
            if (!string.IsNullOrEmpty(UserID) && int.TryParse(UserID, out int id))
            {
                try
                {
                    Order order = new Order();

                    Orders.DataSource = order.GetOrdersByUserID(id);
                    Orders.DataBind();
                }
                catch (Exception exc)
                {
                    throw exc;
                }
            }

        }

        protected void Orders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Orders.PageIndex = e.NewPageIndex;
            Orders.DataBind();
        }
    }
}