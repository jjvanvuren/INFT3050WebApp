using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INFT3050WebApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Hide and disable the "My Account" link
            Master.AccountLinkEnabled = false;
            Master.AccountLinkVisible = false;

            // Hide and disable the "Logout" link
            Master.LogoutLinkEnabled = false;
            Master.LogoutLinkVisible = false;

            if (!IsPostBack)
            {
                var db = new DAL.DummyDB();
                var books = db.GetBooks();

                ImageRepeater.DataSource = books;
                ImageRepeater.DataBind();
            }
        }
    }
}