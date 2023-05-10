using ShoppingAppBLL.ModelViews;
using ShoppingAppDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppBLL.Repository.Interfaces
{
    public interface IOrderRepository
    {
        //public Order AddOrder(int userId, int BillingAddressId,int shippingAddressId, string mode, string cardNumber, string cardHolderName, [Optional] int cvvPin);
        public Order AddOrder(int userId, int BillingAddressId, int shippingAddressId, string mode);
        //public Tuple<List<OrderView>, double> ViewOrdersByOrderID(int id);
        public List<OrderView> ViewOrdersByOrderID(int id);
    }
}
