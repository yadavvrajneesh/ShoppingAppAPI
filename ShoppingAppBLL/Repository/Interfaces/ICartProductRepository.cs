using ShoppingAppBLL.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppBLL.Repository.Interfaces
{
    public interface ICartProductRepository
    {
        //public Tuple<List<CartProductView>, float> AddProductInCart(int userid, int productid, int cartcount);//from user id we will get to know the cart id
        //public Tuple<List<CartProductView>, float> RemoveProductsInCart(int userid, int productid, int cartcount);//from user id we will get to know the cart id
        public List<CartProductView> AddProductInCart(int userid, int productid, int cartcount);//from user id we will get to know the cart id
        public List<CartProductView> RemoveProductsInCart(int userid, int productid, int cartcount);//from user id we will get to know the cart id

    }
}
