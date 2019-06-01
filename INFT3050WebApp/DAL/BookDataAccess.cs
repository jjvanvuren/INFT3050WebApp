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
        private string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["UsedBooksConnectionString"].ConnectionString;
            }
        }

        // Method used to get all books
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<Book> GetBooks()
        {
            List<Book> books = new List<Book>();
                string sql = @"SELECT [item].[itemID], [price], [stockQuantity], [longDescription], [shortDescription], [imagePath], [thumbnailPath], 
                            [ISBN], [title], [datePublished], [secondaryTitle], [isBestSeller], [publisher], [isActive]
                            FROM [dbo].[item] 
                            INNER JOIN [book] ON [item].[itemID] = [book].[itemID]
                            WHERE isActive = 1;";

                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(sql, con))
                    {
                        con.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        { 
                            Book newBook = CreateBook(reader);
                            AuthorDataAccess newAuthor = new AuthorDataAccess();
                            newBook.Authors = newAuthor.getAuthors(newBook.Id);
                            CategoryDataAccess newCategory = new CategoryDataAccess();
                            newBook.Categories = newCategory.getCategories(newBook.Id);
                            books.Add(newBook);
                        }

                    }
                }
                return books;
        }
        // Method used to get all books for admin use
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<Book> GetAdminBooks()
        {
            List<Book> books = new List<Book>();
            string sql = @"SELECT [item].[itemID], [price], [stockQuantity], [longDescription], [shortDescription], [imagePath], [thumbnailPath], 
                            [ISBN], [title], [datePublished], [secondaryTitle], [isBestSeller], [publisher],[isActive]
                            FROM [dbo].[item] 
                            INNER JOIN [book] ON [item].[itemID] = [book].[itemID]";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Book newBook = CreateBook(reader);
                        AuthorDataAccess newAuthor = new AuthorDataAccess();
                        newBook.Authors = newAuthor.getAuthors(newBook.Id);
                        CategoryDataAccess newCategory = new CategoryDataAccess();
                        newBook.Categories = newCategory.getCategories(newBook.Id);
                        books.Add(newBook);
                    }

                }
            }
            return books;
        }

        // Method used to get books by their ID
        [DataObjectMethod(DataObjectMethodType.Select)]
        public Book GetBookById(int bookID)
        {
            string sql = @"SELECT [item].[itemID], [price], [stockQuantity], [longDescription], [shortDescription], [imagePath], [thumbnailPath], 
                            [ISBN], [title], [datePublished], [secondaryTitle], [isBestSeller], [publisher], [isActive]
                            FROM [dbo].[item] 
                            INNER JOIN [book] ON [item].[itemID] = [book].[itemID]
                            WHERE [item].[itemID]=@Id;";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.Add(new SqlParameter("Id", bookID));
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Book newBook = CreateBook(reader);
                        AuthorDataAccess newAuthor = new AuthorDataAccess();
                        newBook.Authors = newAuthor.getAuthors(newBook.Id);
                        CategoryDataAccess newCategory = new CategoryDataAccess();
                        newBook.Categories = newCategory.getCategories(newBook.Id);
                        return newBook;
                    }

                }
            }
            return null;
        }

        // Method for updating books that have been edited by admins
        // Method is currently untested
        // Method should return 0, if it returns anything else somethings wrong
        [DataObjectMethod(DataObjectMethodType.Update)]
        public int UpdateBookById(Book bookUpdate)
        {
            int firstRowsEffected;
            int secondRowsEffected;
            string sql = @"UPDATE dbo.item SET [price] = @price, [stockQuantity] = @stockQuantity, [imagePath] = @imagePath, [thumbnailPath] = @thumbnailPath 
                            WHERE [itemID]=@Id;";

            string sql2 = @"UPDATE dbo.book SET [title] = @title
                            WHERE [book].itemID=@Id;";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("Id", bookUpdate.Id);
                    command.Parameters.AddWithValue("price", bookUpdate.Price);
                    command.Parameters.AddWithValue("stockQuantity", bookUpdate.StockQuantity);
                    command.Parameters.AddWithValue("imagePath", bookUpdate.ImagePath);
                    command.Parameters.AddWithValue("thumbnailPath", bookUpdate.ThumbnailPath);
                    con.Open();
                    firstRowsEffected = command.ExecuteNonQuery();
                    con.Close();
                }

                using (SqlCommand command = new SqlCommand(sql2, con))
                {
                    command.Parameters.AddWithValue("Id", bookUpdate.Id);
                    command.Parameters.AddWithValue("Title", bookUpdate.Title);
                    con.Open();
                    secondRowsEffected = command.ExecuteNonQuery();
                    con.Close();
                }
                
            }

            return firstRowsEffected - secondRowsEffected;
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public int Updatebook(Book newBook)
        {
            Int32 newId;

            string sql = @"UPDATE item 
                            SET [Book].title =@title, price= @price, stockQuantity=  @stockQuantity, imagePath= @imagePath, thumbnailPath=@thumbnailPath
                            FROM item                                
                            INNER JOIN [book] ON [item].[itemID] = [book].[itemID]
                                WHERE [item].[itemID]=@Id; ";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.Add(new SqlParameter("Id", newBook.Id));
                    command.Parameters.Add(new SqlParameter("title", newBook.Price));
                    command.Parameters.Add(new SqlParameter("price", newBook.Price));
                    command.Parameters.Add(new SqlParameter("stockQuantity", newBook.StockQuantity));
                    command.Parameters.Add(new SqlParameter("imagePath", newBook.ImagePath));
                    command.Parameters.Add(new SqlParameter("thumbnailPath", newBook.ThumbnailPath));
                    con.Open();
                    newId = Convert.ToInt32((object)command.ExecuteNonQuery());
                    return 0;
                }
            }

        }

        // Method to "delete" item by setting status flag to 0
        // returns the number of rows effected (should be 1)
        // Untested
        [DataObjectMethod(DataObjectMethodType.Update)]
        public int DeleteItemById(int itemId, Boolean ActiveStatus)
        {
            string sql = @"UPDATE dbo.item SET [isActive] = @isActive
                            WHERE [itemID]=@Id;";

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("Id", itemId);
                    command.Parameters.AddWithValue("isActive", ActiveStatus);
                    con.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        //[DataObjectMethod(DataObjectMethodType.Insert)]
        //public int AddBook(Book book)
        //{
        //    string sql = @"INSERT INTO item (price, stockQuantity, longDescription, shortDescription, imagePath, thumbnailPath, isActive)
        //                   VALUES (@price, @stockQuantity, @longDescription, @shortDescription, @imagePath, @thumbnailPalth, 1); ";
        //    string sql2 = @"INSERT INTO book (price, stockQuantity, longDescription, shortDescription, imagePath, thumbnailPath, isActive)
        //                   VALUES (@price, @stockQuantity, @longDescription, @shortDescription, @imagePath, @thumbnailPalth, 1); ";

        //}


        // Method used to get books by their Category
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<Book> SearchBooksByTitle(string searchString)
        {
            List<Book> books = new List<Book>();
            string sql = @"SELECT [item].[itemID], [price], [stockQuantity], [longDescription], [shortDescription], [imagePath], [thumbnailPath], 
                            [ISBN], [title], [datePublished], [secondaryTitle], [isBestSeller], [publisher], [isActive]
                            FROM [dbo].[item] 
                            INNER JOIN [book] ON [item].[itemID] = [book].[itemID]
                            WHERE isActive = 1 AND CONTAINS (title, @searchString);";
            if (searchString == null)
            {
                return GetBooks();
            }
            else
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(sql, con))
                    {
                        command.Parameters.Add(new SqlParameter("searchString", searchString));
                        con.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Book newBook = CreateBook(reader);
                            AuthorDataAccess newAuthor = new AuthorDataAccess();
                            newBook.Authors = newAuthor.getAuthors(newBook.Id);
                            CategoryDataAccess newCategory = new CategoryDataAccess();
                            newBook.Categories = newCategory.getCategories(newBook.Id);
                            books.Add(newBook);
                        }
                        con.Close();
                    }
                }
                return books;
            }
        }

        // Method used to get books by their Category
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<Book> GetBooksByCategory(int CategoryId)
        {
            List<Book> books = new List<Book>();
            string sql = @"SELECT [item].[itemID], [price], [stockQuantity], [longDescription], [shortDescription], [imagePath], [thumbnailPath], 
                            [ISBN], [title], [datePublished], [secondaryTitle], [isBestSeller], [publisher], [isActive]
                            FROM [dbo].[item] 
                            INNER JOIN [book] ON [item].[itemID] = [book].[itemID]
                            INNER JOIN [bookCategory] ON [book].[itemID] = [bookCategory].[itemID]
                            WHERE [bookCategory].[categoryID]=@Id;";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.Add(new SqlParameter("Id", CategoryId));
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Book newBook = CreateBook(reader);
                        AuthorDataAccess newAuthor = new AuthorDataAccess();
                        newBook.Authors = newAuthor.getAuthors(newBook.Id);
                        CategoryDataAccess newCategory = new CategoryDataAccess();
                        newBook.Categories = newCategory.getCategories(newBook.Id);
                        books.Add(newBook);
                    }

                }

                return books;
            }
        }

        // Method used to create a book object from the reader
        private static Book CreateBook(SqlDataReader reader)
        {
            Book book = new Book();
            book.Id = (int)reader["itemID"];
            book.Price = (double)reader.GetDecimal(1);
            book.StockQuantity = (int)reader["stockQuantity"];
            book.LongDescription = reader["longDescription"].ToString();
            book.ShortDescription = reader["shortDescription"].ToString();
            book.ImagePath = reader["imagePath"].ToString();
            book.ThumbnailPath = reader["thumbnailPath"].ToString();
            book.Isbn = reader["ISBN"].ToString();
            book.Title = reader["title"].ToString();
            book.DatePublished = (DateTime)reader["datePublished"];
            book.SecondaryTitle = reader["secondaryTitle"].ToString();
            book.IsBestSeller = (bool)reader.GetSqlBoolean(11);
            book.Publisher = reader["publisher"].ToString();
            book.IsActive = (bool)reader.GetSqlBoolean(13);

            return book;
        }

        // Method used to create Author object from the reader
        private static Author CreateAuthor(SqlDataReader reader)
        {
            Author author = new Author();
            author.Id = (int)reader["authorID"];
            author.Description = (string)reader.GetSqlString(15);
            author.FirstName = (string)reader.GetSqlString(13);
            author.LastName = (string)reader.GetSqlString(14);

            return author;
        }

        // Method used to create Category object from the reader
        private static Category CreateCategory(SqlDataReader reader)
        {
            Category category = new Category();
            category.Id = (int)reader["categoryID"];
            category.Name = (string)reader.GetSqlString(16);
            category.Description = (string)reader.GetSqlString(17);

            return category;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int SubmitBook(Book newBook)
        {
            Int32 newId;

            string sql = @"INSERT INTO item (price, stockQuantity, longDescription, shortDescription, imagePath, thumbnailPath, isActive)
                                VALUES (@price, @stockQuantity, @longDescription, @shortDescription, @imagePath, @thumbnailPath, 1)
                                SELECT SCOPE_IDENTITY()";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.Add(new SqlParameter("price", newBook.Price));
                    command.Parameters.Add(new SqlParameter("stockQuantity", newBook.StockQuantity));
                    command.Parameters.Add(new SqlParameter("longDescription", newBook.LongDescription));
                    command.Parameters.Add(new SqlParameter("shortDescription", newBook.ShortDescription));
                    command.Parameters.Add(new SqlParameter("imagePath", newBook.ImagePath));
                    command.Parameters.Add(new SqlParameter("thumbnailPath", newBook.ThumbnailPath));
                    con.Open();
                    newId = Convert.ToInt32((object)command.ExecuteScalar());
                }
            }
            sql = @"INSERT INTO book (itemID, ISBN, title, datePublished, secondaryTitle, isBestSeller, publisher)
                                VALUES (@itemID, @ISBN, @title, @datePublished, @secondaryTitle, @isBestSeller, @publisher)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.Add(new SqlParameter("itemID", newId));
                    command.Parameters.Add(new SqlParameter("ISBN", newBook.Isbn));
                    command.Parameters.Add(new SqlParameter("title", newBook.Title));
                    command.Parameters.Add(new SqlParameter("datePublished", newBook.DatePublished));
                    command.Parameters.Add(new SqlParameter("secondaryTitle", newBook.SecondaryTitle));
                    command.Parameters.Add(new SqlParameter("isBestSeller", newBook.IsBestSeller));
                    command.Parameters.Add(new SqlParameter("publisher", newBook.Publisher));
                    con.Open();
                    command.ExecuteNonQuery();
                    return newId;
                }
            }
        }

    }
}