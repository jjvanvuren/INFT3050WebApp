using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INFT3050WebApp.BL;

namespace INFT3050WebApp.DAL
{
    interface IUserDataAccess
    {
        User GetUserByEmail(string strEmail);
        string GetPasswordHash(string strEmail);
        bool CheckUserExists(string strEmail);
        User GetUserById(int Id);
        int RegisterUser(User user);
        int VerifyUser(User user);
        int UpdateKey(User user);
        int UpdatePassword(User user);
    }
}