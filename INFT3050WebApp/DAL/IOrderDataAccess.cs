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
        void submitCart(int userID, Address userAddress, int ipostageOptionID, List<CartItem> Cart, double dTotalPrice, DateTime PurchaseTime);
        Order GetOrder(int iPaymentId, int iUserId);
    }
}