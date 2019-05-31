using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls;

namespace INFT3050WebApp
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void lnkAllBooks_Click(object sender, EventArgs e)
        {
            Response.Redirect("Books");
        }

        protected void lnkHistory_Click(object sender, EventArgs e)
        {
            var url = FriendlyUrl.Href("~/UL/BooksByCategory", 1);

            Response.Redirect(url);
        }

        protected void lnkThriller_Click(object sender, EventArgs e)
        {
            var url = FriendlyUrl.Href("~/UL/BooksByCategory", 2);

            Response.Redirect(url);
        }

        protected void lnkSciFi_Click(object sender, EventArgs e)
        {
            var url = FriendlyUrl.Href("~/UL/BooksByCategory", 3);

            Response.Redirect(url);
        }

        protected void lnkHorror_Click(object sender, EventArgs e)
        {
            var url = FriendlyUrl.Href("~/UL/BooksByCategory", 4);

            Response.Redirect(url);
        }

        protected void lnkCrime_Click(object sender, EventArgs e)
        {
            var url = FriendlyUrl.Href("~/UL/BooksByCategory", 5);

            Response.Redirect(url);
        }

        protected void lnkFantasy_Click(object sender, EventArgs e)
        {
            var url = FriendlyUrl.Href("~/UL/BooksByCategory", 6);

            Response.Redirect(url);
        }

        protected void lnkArt_Click(object sender, EventArgs e)
        {
            var url = FriendlyUrl.Href("~/UL/BooksByCategory", 7);

            Response.Redirect(url);
        }

        protected void lnkTechnology_Click(object sender, EventArgs e)
        {
            var url = FriendlyUrl.Href("~/UL/BooksByCategory", 8);

            Response.Redirect(url);
        }


    }
}