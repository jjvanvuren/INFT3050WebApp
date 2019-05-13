using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using INFT3050WebApp.BL;

namespace INFT3050WebApp.DAL
{
    [DataObject(true)]
    public class BookDataAccess : IBookDataAccess
    {
        //private string ConnectionString
        //{
        //    get
        //    {
        //        return ConfigurationManager.ConnectionStrings["UsedBooksConnectionString"].ConnectionString;
        //    }
        //}

        // String used to connect to the Azure SQL Server
        static String ConnectionString = "Server=tcp:inft3050book.database.windows.net,1433;Initial " +
            "Catalog=INFT3050;Persist Security Info=False;User ID = editAdmin; Password=INFT3050!;" +
            "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";

        // Method used to get all books
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<Book> GetBooks()
        {
            List<Book> books = new List<Book>();
            string sql = @"SELECT [item].[itemID], [price], [stockQuantity], [longDescription], [shortDescription], [imagePath], [thumbnailPath], 
                            [ISBN], [title], [datePublished], [secondaryTitle], [isBestSeller], [publisher], [author].[firstName], [author].[lastName], [author].[description], 
                            [category].[name], [category].[description], [author].[authorID], [category].[categoryID]
                            FROM [dbo].[item] 
                            INNER JOIN [book] ON [item].[itemID] = [book].[itemID]
                            INNER JOIN [bookAuthor] ON [book].[itemID] = [bookAuthor].[itemID]
                            INNER JOIN [author] ON [bookAuthor].[authorID] = [author].[authorID]
                            INNER JOIN [bookCategory] ON [book].[itemID] = [bookCategory].[itemID]
                            INNER JOIN [category] ON [bookCategory].[categoryID] = [category].[categoryID];";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Book newBook = CreateBook(reader);
                        books.Add(newBook);
                    }
                }
            }
            return books;
        }
        // Method used to get books by their ID
        [DataObjectMethod(DataObjectMethodType.Select)]
        public Book GetBookById(int Id)
        {
            string sql = @"SELECT [item].[itemID], [price], [stockQuantity], [longDescription], [shortDescription], [imagePath], [thumbnailPath], 
                            [ISBN], [title], [datePublished], [secondaryTitle], [isBestSeller], [publisher], [author].[firstName], [author].[lastName], [author].[description], 
                            [category].[name], [category].[description], [author].[authorID], [category].[categoryID]
                            FROM [dbo].[item] 
                            INNER JOIN [book] ON [item].[itemID] = [book].[itemID]
                            INNER JOIN [bookAuthor] ON [book].[itemID] = [bookAuthor].[itemID]
                            INNER JOIN [author] ON [bookAuthor].[authorID] = [author].[authorID]
                            INNER JOIN [bookCategory] ON [book].[itemID] = [bookCategory].[itemID]
                            INNER JOIN [category] ON [bookCategory].[categoryID] = [category].[categoryID];
                            WHERE [item].[itemID]=@Id ";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.Add(new SqlParameter("Id", Id));
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        return CreateBook(reader);
                    }
                }
            }
            return null;
        }

        // Method used to get books by their Category
        [DataObjectMethod(DataObjectMethodType.Select)]
        public Book GetBookByCategory(int Id)
        {
            string sql = @"SELECT [item].[itemID], [price], [stockQuantity], [longDescription], [shortDescription], [imagePath], [thumbnailPath], 
                            [ISBN], [title], [datePublished], [secondaryTitle], [isBestSeller], [publisher], [author].[firstName], [author].[lastName], [author].[description], 
                            [category].[name], [category].[description], [author].[authorID], [category].[categoryID]
                            FROM [dbo].[item] 
                            INNER JOIN [book] ON [item].[itemID] = [book].[itemID]
                            INNER JOIN [bookAuthor] ON [book].[itemID] = [bookAuthor].[itemID]
                            INNER JOIN [author] ON [bookAuthor].[authorID] = [author].[authorID]
                            INNER JOIN [bookCategory] ON [book].[itemID] = [bookCategory].[itemID]
                            INNER JOIN [category] ON [bookCategory].[categoryID] = [category].[categoryID];
                            WHERE [category].[categoryID]=@Id ";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.Add(new SqlParameter("Id", Id));
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        return CreateBook(reader);
                    }
                }
            }
            return null;
        }

        // Method used to create a book object from the reader
        private static Book CreateBook(SqlDataReader reader)
        {
            Book book = new Book();
            book.Id = (int)reader["item.itemID"];
            book.Price = (double)reader["price"];
            book.StockQuantity = (int)reader["stockQuantity"];
            book.LongDescription = reader["longDescription"].ToString();
            book.ShortDescription = reader["shortDescription"].ToString();
            book.ImagePath = reader["imagePath"].ToString();
            book.ThumbnailPath = reader["thumbnailPath"].ToString();
            book.Isbn = reader["ISBN"].ToString();
            book.Title = reader["title"].ToString();
            book.DatePublished = (DateTime)reader["datePublished"];
            book.SecondaryTitle = reader["secondaryTitle"].ToString();
            book.IsBestSeller = (int)reader["isBestSeller"];
            book.Publisher = reader["publisher"].ToString();
            book.Author.Id = (int)reader["author.authorID"];
            book.Author.Description = reader["author.description"].ToString();
            book.Author.FirstName = reader["author.firstName"].ToString();
            book.Author.LastName = reader["author.lastName"].ToString();
            book.Category.Id = (int)reader["category.categoryID"];
            book.Category.Name = reader["category.name"].ToString();
            book.Category.Description = reader["category.description"].ToString();

            return book;
        }
    }
}