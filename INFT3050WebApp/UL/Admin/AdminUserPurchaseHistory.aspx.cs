using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INFT3050WebApp.UL.Admin
{
    public partial class AdminUserPurchaseHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var idString = Request.QueryString["id"];
            int id;
            if (!string.IsNullOrEmpty(idString) && int.TryParse(idString, out id))
            {
                // using dummy database
                DAL.DummyDB db = new DAL.DummyDB();

                if (!IsPostBack)
                {
                    // get book from db using GetBookById method
                    //var purchaseHistory = db.GetOrdersByUserId(id);
                    //if (purchaseHistory != null)
                    //{
                        
                    //}
                }
            }
        }
    }
}