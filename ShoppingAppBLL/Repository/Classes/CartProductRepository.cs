using Microsoft.EntityFrameworkCore.Storage;
using ShoppingAppBLL.ModelViews;
using ShoppingAppBLL.Repository.Interfaces;
using ShoppingAppDAL.Context;
using ShoppingAppDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppBLL.Repository.Classes
{
    public class CartProductRepository : ICartProductRepository
    {
        DataBaseContext _context;
        ICartRepository _cartRepository;
        public CartProductRepository(DataBaseContext context, ICartRepository repository)
        {
            _context = context;
            _cartRepository = repository;
        }

        public List<CartProductView> AddProductInCart(int userid, int productid, int cartcount)
        {
            Cart cart = _context.Cart.FirstOrDefault(c => c.UserId == userid);
            Product product = _context.Products.FirstOrDefault(p => p.ProductId == productid);
            if (cart != null && product.ProductCount >= cartcount)
            {
                CartProducts prod = _context.CartProducts.FirstOrDefault(cp => cp.ProductId == productid && cp.CartId == cart.CartId);
                if (prod != null)
                {

                    prod.CartCount = prod.CartCount + cartcount;
                    product.ProductCount = product.ProductCount - cartcount;
                    cart.CartPrice += cartcount * product.ProductPrice;
                    prod.CartId = prod.CartId;
                    prod.ProductId = productid;
                    _context.Update(prod);
                    _context.Update(product);
                    _context.Update(cart);

                    _context.SaveChanges();

                }
                else if (prod == null)
                {
                    CartProducts prod1 = new CartProducts();
                    prod1.CartCount = cartcount;
                    product.ProductCount = product.ProductCount - cartcount;
                    cart.CartPrice += cartcount * product.ProductPrice;
                    prod1.CartId = cart.CartId;
                    prod1.ProductId = productid;
                    _context.Add(prod1);
                    _context.Update(product);
                    _context.Update(cart);
                    _context.SaveChanges();
                }
            }
            else
            {
                Console.WriteLine("Only " + product.ProductCount + "items in inventory");
            }
            return _cartRepository.GetCartItemsyByUserID(userid);
        }

        public List<CartProductView> RemoveProductsInCart(int userid, int productid, int cartcount)
        {
            Cart cart = _context.Cart.FirstOrDefault(c => c.UserId == userid);
            Product product = _context.Products.FirstOrDefault(p => p.ProductId == productid);
            if (cart != null)
            {
                CartProducts prod = _context.CartProducts.FirstOrDefault(cp => cp.ProductId == productid && cp.CartId == cart.CartId);
                if (prod != null && prod.CartCount >= cartcount)
                {
                    prod.CartCount = prod.CartCount - cartcount;
                    cart.CartPrice -= cartcount * product.ProductPrice;
                    product.ProductCount = product.ProductCount + cartcount;
                    if (prod.CartCount >= 1)
                    {
                        //prod.CartPrice = prod.CartCount * product.ProductPrice;
                        prod.CartId = prod.CartId;
                        prod.ProductId = productid;
                        //  cart.CartPrice -= prod.CartCount * product.ProductPrice;
                        _context.Update(prod);
                        _context.Update(product);
                        _context.Update(cart);
                        _context.SaveChanges();
                    }
                    else if (prod.CartCount == cartcount || prod.CartCount == 0)
                    {
                        _context.Update(cart);
                        _context.Update(product);
                        _context.Remove(prod);
                        _context.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Only " + prod.CartCount + "items in CART");
                    }
                }


            }
            return _cartRepository.GetCartItemsyByUserID(userid);
        }
    }
}
