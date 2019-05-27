using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INFT3050WebApp.DAL;

namespace INFT3050WebApp.BL
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }

        public Author()
        {
            FirstName = "";
            LastName = "";
            Description = "";
        }
        public Author(string SearchFirstName, string SearchLastName)
        {
            var db = new AuthorDataAccess();
            Author author = db.getAuthor(SearchFirstName, SearchLastName);
            string Description = "";
            if (author == null)
            {
                db.AddAuthor(SearchFirstName, SearchLastName,Description);
            }

        }

        public List<Author> SearchAuthorByName(string SearchFirstName, string SearchLastName)
        {
            List<Author> Authors = new List<Author>();
            AuthorDataAccess connection = new AuthorDataAccess();
            Authors = connection.GetAuthors(SearchFirstName, SearchLastName);

                return Authors;
        }

        public Author getAuthor(int ID)
        {
            Author Author = new Author();
            AuthorDataAccess connection = new AuthorDataAccess();
            Author = connection.getAuthor(ID);

            return Author;
        }

        public Author getAddAuthor(string SearchFirstName, string SearchLastName)
        {
            var db = new AuthorDataAccess();
            Author author = db.getAuthor(SearchFirstName, SearchLastName);

            if (author != null)
            {
                return author;
            }
            return null;
        }


    }


}