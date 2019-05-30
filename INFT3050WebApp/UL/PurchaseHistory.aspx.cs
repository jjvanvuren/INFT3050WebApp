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
            // Check if user is logged in to use correct master page
            if (Session["userSession"] != null)
            {
                Page.MasterPageFile = "~/UL/Customer.Master";
            }
            else
            {
                Page.MasterPageFile = "~/UL/Site.Master";
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Enable SSL
                if (!Request.IsSecureConnection)
                {
                    string url = ConfigurationManager.AppSettings["SecurePath"] + "UL/Admin/PurchaseHistory.aspx";
                    Response.Redirect(url);
                }

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
                        Server.Transfer("~/UL/DefaultError.aspx?handler=PurchaseHistory.aspx", true);
                    }

                }     
            }
        }
    }
}