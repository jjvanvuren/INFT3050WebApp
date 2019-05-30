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

        //protected void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Response.Redirect("BooksByCategory.aspx?id=" + ddlCategories.SelectedItem.Value);
        //}

        protected void lnkAllBooks_Click(object sender, EventArgs e)
        {
            Response.Redirect("Books.aspx");
        }

        protected void lnkHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("BooksByCategory.aspx?id=" + 1);
        }

        protected void lnkThriller_Click(object sender, EventArgs e)
        {
            Response.Redirect("BooksByCategory.aspx?id=" + 2);
        }

        protected void lnkSciFi_Click(object sender, EventArgs e)
        {
            Response.Redirect("BooksByCategory.aspx?id=" + 3);
        }

        protected void lnkHorror_Click(object sender, EventArgs e)
        {
            Response.Redirect("BooksByCategory.aspx?id=" + 4);
        }

        protected void lnkCrime_Click(object sender, EventArgs e)
        {
            Response.Redirect("BooksByCategory.aspx?id=" + 5);
        }

        protected void lnkFantasy_Click(object sender, EventArgs e)
        {
            Response.Redirect("BooksByCategory.aspx?id=" + 6);
        }

        protected void lnkArt_Click(object sender, EventArgs e)
        {
            Response.Redirect("BooksByCategory.aspx?id=" + 7);
        }

        protected void lnkTechnology_Click(object sender, EventArgs e)
        {
            Response.Redirect("BooksByCategory.aspx?id=" + 8);
        }


    }
}