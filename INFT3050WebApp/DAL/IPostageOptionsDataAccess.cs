using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INFT3050WebApp.BL;

namespace INFT3050WebApp.DAL
{
    interface IPostageOptionsDataAccess
    {
        IEnumerable <PostageOption> GetPostageOptions();
        int DeletePostageOptionById(int Id);
        int UpdatePostageOptionById(int Id, double price, string name);
        int AddPostageOption(string Name, double Price);
        PostageOption GetPostageOption(int PostageID);
    }
}