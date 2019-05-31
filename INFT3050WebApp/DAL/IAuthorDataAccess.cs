using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INFT3050WebApp.BL;

namespace INFT3050WebApp.DAL
{
    interface IAuthorDataAccess
    {
        List<Author> GetAuthors(string SearchFirstName, string SearchLastName);
        void AddAuthor(string SearchFirstName, string SearchLastName, string newDecription);
        Author getAuthor(int ID);
        List<Author> getAuthors(int BookID);
        Author getAuthor(string SearchFirstName, string SearchLastName);
        void ConnectBookAuthor(int BookID, List<Author> Authors);
    }
}