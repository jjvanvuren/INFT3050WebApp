using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INFT3050WebApp.BL;

namespace INFT3050WebApp.DAL
{
    interface IBookDataAccess
    {
        IEnumerable<Book> GetBooks();
        Book GetBookById(int Id);
        IEnumerable<Book> GetBooksByCategory(int categoryId);

    }
}