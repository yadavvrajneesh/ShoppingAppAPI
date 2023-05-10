using ShoppingAppBLL.ModelViews;
using ShoppingAppBLL.Repository.Interfaces;
using ShoppingAppDAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppBLL.Repository.Classes
{
    public class CartRepository : ICartRepository
    {
        DataBaseContext _context;
        List<CartProductView> view;
        public CartRepository(DataBaseContext context)
        {
            _context = context;
        }

        public  List<CartProductView> GetCartItemsyByUserID(int id)
        {
            var user = _context.Cart.FirstOrDefault(c => c.UserId == id);


            if (user != null)
            {
                view = (from _cart in _context.Cart
                        join _cartproduct in _context.CartProducts on _cart.CartId equals _cartproduct.CartId
                        join _product in _context.Products on _cartproduct.ProductId equals _product.ProductId
                        where _cart.UserId == id
                        select new CartProductView
                        {

                            ProductId = _cartproduct.ProductId,
                            CartCount = (int)_cartproduct.CartCount,
                            CartPrice= _cart.CartPrice,
                            ProductName = _product.ProductName,
                            ProductDescription = _product.ProductDescription,
                            ProductPrice = (float)(_product.ProductPrice * _cartproduct.CartCount)
                        }).ToList();


            }
            return view;
        }
    }
}
