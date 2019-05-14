using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INFT3050WebApp.UL
{
    public partial class BooksByCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get ID and try parse
            var idString = Request.QueryString["id"];
            int id;
            if (!string.IsNullOrEmpty(idString) && int.TryParse(idString, out id))
            {
                // Create dummyDB
                DAL.ICategoryDataAccess db = new DAL.CategoryDataAccess();

                if (!IsPostBack)
                {
                    // get book from db using GetBookById method
                    var category = db.GetCategoryById(id);
                    if (category != null)
                    {
                        // Use data for page elements
                        lblCategoryName.Text = category.Name;
                        lblCategoryDescription.Text = category.Description;

                        bookDataSource.SelectParameters.Clear();
                        bookDataSource.SelectParameters.Add("CategoryId", category.Id.ToString());
                    }
                }
            }
        }

        protected void GridBooks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // When clicking the View button take the user to the matching book's page
            if (e.CommandName == "cmdView")
            {
                Response.Redirect("Book.aspx?id=" + e.CommandArgument);
            }

        }
    }
}