using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INFT3050WebApp.BL;

namespace INFT3050WebApp.DAL
{
    interface IOrderDataAccess
    {
        IEnumerable<Order> GetOrdersByUserID(int Id);
        Order GetOrder(int iPaymentId, int iUserId);
        int submitCart(int userID, Address userAddress, int ipostageOptionID, List<CartItem> Cart, double dTotalPrice, DateTime PurchaseTime);
        List<Address> GetPostCodes();
        void AddPostCode(string City, string State, int postCode);
    }
}