using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INFT3050WebApp.BL;

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
                if (!IsPostBack)
                {
                    try
                    {
                        Category category = new Category(id);

                        if (category != null)
                        {
                            // Use data for page elements
                            lblCategoryName.Text = category.Name;
                            lblCategoryDescription.Text = category.Description;

                            bookDataSource.SelectParameters.Clear();
                            bookDataSource.SelectParameters.Add("CategoryId", category.Id.ToString());
                        }
                    }
                    catch (Exception exception)
                    {
                        //string exceptionString = "?error=" + exception.Message;

                        //if (exception.InnerException != null)
                        //{
                        //    exceptionString += "&innerex=" + exception.GetType().ToString() + "<br/>" + exception.InnerException.Message;
                        //    exceptionString += "&stacktrace=" + exception.InnerException.StackTrace;
                        //}
                        //else
                        //{
                        //    exceptionString += "&innerex=" + exception.GetType().ToString();
                        //    if (exception.StackTrace != null)
                        //    {
                        //        exceptionString += "&stacktrace=" + exception.StackTrace.ToString().TrimStart();
                        //    }
                        //}

                        //Response.Redirect("DefaultError.aspx" + exceptionString);

                        Server.Transfer("DefaultError.aspx?handler=BooksByCategory.aspx", true);
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