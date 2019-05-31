using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INFT3050WebApp
{
    public partial class Search : System.Web.UI.Page
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

        }

        protected void GridSearch_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // When clicking the View button take the user to the matching book's page
            if (e.CommandName == "cmdView")
            {
                string idString = e.CommandArgument.ToString();

                var url = FriendlyUrl.Href("~/UL/Book", idString);

                Response.Redirect(url);
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string[] split = tbxSearch.Text.Split(null);
            string searchString = "";

            // Add each separate inputed word to search string separated by OR
            for (int i = 0; i < split.Length; i++)
            {
                if (i == split.Length - 1)
                {
                    searchString = searchString + split[i];
                }
                else
                {
                    searchString = searchString + split[i] + " OR ";
                }
            }

            bookDataSource.SelectParameters.Clear();
            bookDataSource.SelectParameters.Add("searchString", searchString);

            this.GridBooks.DataBind();

        }
    }
}