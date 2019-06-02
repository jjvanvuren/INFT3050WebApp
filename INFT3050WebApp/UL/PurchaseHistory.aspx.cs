using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INFT3050WebApp.BL;

namespace INFT3050WebApp.UL
{
    public partial class PurchaseHistory : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            // Check if user is logged in
            if (Session["userSession"] != null)
            {
                Page.MasterPageFile = "~/UL/Customer.Master";
            }
            else
            {
                // Check if the session has expired
                Response.Redirect("SessionExpired.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Enable SSL
            if (!Request.IsSecureConnection)
            {
                string url = ConfigurationManager.AppSettings["SecurePath"] + "UL/PurchaseHistory.aspx";
                Response.Redirect(url);
            }

            // Get the current users ID and use the ID to get and display the users purchase history 
            UserSession query = (UserSession)Session[UserSession.SESSION_KEY];
            if (query != null)
            {
                User currentUser = new User(query.SessionId);

                int id = currentUser.Id;

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