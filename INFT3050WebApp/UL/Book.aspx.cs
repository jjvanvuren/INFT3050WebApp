using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace INFT3050WebApp.UL
{
    public partial class Book : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // get id from query string and try to parse
            var idString = Request.QueryString["id"];
            int id;
            if (!string.IsNullOrEmpty(idString) && int.TryParse(idString, out id))
            {
                // using dummy database
                DAL.DummyDB db = new DAL.DummyDB();

                if (!IsPostBack)
                {
                    // get book from db using GetBookById method
                    var book = db.GetBookById(id);
                    if (book != null)
                    {
                        // set up page elements
                        lblTitle.Text = book.Title;
                        imgBook.ImageUrl = book.ImagePath;
                        lblDescription.Text = book.LongDescription;
                        lblPrice.Text = "Price: $" + book.Price.ToString();
                        lblAuthor.Text = book.Author.FirstName + " " + book.Author.LastName;
                        lblQuantity.Text = "In Stock: " + book.StockQuantity.ToString();
                        lblPublisher.Text = "Published: " + book.Publisher;
                        lblDatePublished.Text = book.DatePublished.ToShortDateString();
                    }
                }
            }
        }
    }
}