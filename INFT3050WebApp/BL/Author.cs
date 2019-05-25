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

        public List<Author> SearchAuthorByName(string SearchFirstName, string SearchLastName)
        {
            List<Author> Authors = new List<Author>();
            AuthorDataAccess connection = new AuthorDataAccess();
            Authors = connection.GetAuthors(SearchFirstName, SearchLastName);

                return Authors;
        }

        public string AddAuthorByName(string SearchFirstName, string SearchLastName)
        {
            var db = new AuthorDataAccess();
            Author author = db.getAuthor(SearchFirstName, SearchLastName);

            int id = 0;
            if (author ==null)
            {
                db.AddAuthor(id, SearchFirstName, SearchLastName);
                return "";
            }
    

            return "Author Already in database";
        }


    }


}