using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INFT3050WebApp.BL;
using Microsoft.AspNet.FriendlyUrls;

namespace INFT3050WebApp.UL
{
    public partial class BooksByCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get category ID and tryparse the ID to an integer
            var segments = Request.GetFriendlyUrlSegments();
            int count = segments.Count;
            string idString = segments[0];

            if (!string.IsNullOrEmpty(idString) && int.TryParse(idString, out int id))
            {
                if (!IsPostBack)
                {
                    // Get and display category information
                    try
                    {
                        Category category = new Category(id);

                        if (category != null)
                        {
                            lblCategoryName.Text = category.Name;
                            lblCategoryDescription.Text = category.Description;

                            bookDataSource.SelectParameters.Clear();
                            bookDataSource.SelectParameters.Add("CategoryId", category.Id.ToString());
                        }
                    }
                    catch (Exception exception)
                    {
                        throw exception;
                    }
                }
            }
        }

        protected void GridBooks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // When clicking the View button take the user to the matching book's page
            if (e.CommandName == "cmdView")
            {
                string idString = e.CommandArgument.ToString();

                var url = FriendlyUrl.Href("~/UL/Book", idString);

                Response.Redirect(url);
            }

        }
    }
}