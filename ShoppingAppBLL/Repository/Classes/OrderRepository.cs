using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShoppingAppBLL.ModelViews;
using ShoppingAppBLL.Repository.Interfaces;
using ShoppingAppDAL.Context;
using ShoppingAppDAL.Models;
using ShoppingAppDAL.Models.Shopping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppBLL.Repository.Classes
{
    public class OrderRepository : IOrderRepository
    {
        DataBaseContext _context;
        List<OrderView> view;
        public OrderRepository(DataBaseContext context)
        {
            _context = context;
        }
        public Order AddOrder(int userId, int BillingAddressId, int shippingAddressId, string mode)
        {
            Payment payment = new Payment();
            Order order = new Order();
            
            Cart cart = _context.Cart.FirstOrDefault(cp => cp.UserId == userId);
            CartProducts cartProducts = _context.CartProducts.FirstOrDefault(cp => cp.CartId == cart.CartId);

            order.OrderDate = DateTime.Now;
            order.CartId = cart.UserId;
            order.UserId = userId;
            order.BillingAddressId = BillingAddressId;
            order.ShippingAddressId= shippingAddressId;
            order.OrderPrice = cart.CartPrice;
            _context.Order.Add(order);
            _context.SaveChanges();

            payment.OrderId = order.OrderId;
            payment.Mode = mode;
            if (mode == "COD")
            {
                payment.Status = "Pending";
                payment.Paid = 0.0;
                payment.Balance = cart.CartPrice;
            }
            else if (mode == "CARD")
            {
                payment.Status = "paid";
                payment.Balance = 0.0;
                payment.Paid = cart.CartPrice;
            }
            
            _context.Payments.Add(payment);
            _context.SaveChanges();
            List<CartProducts> cartProducts1 = _context.CartProducts.Where(cp => cp.CartId == cart.CartId).ToList();
            _context.CartProducts.RemoveRange(cartProducts1);
            _context.SaveChanges();

            cart.CartPrice = 0;
            _context.Cart.Update(cart);
            _context.SaveChanges();
            return order;
        }
        public List<OrderView> ViewOrdersByOrderID(int id)
        {
            var order = _context.Order.FirstOrDefault(c => c.OrderId == id);
            var cart = _context.Cart.FirstOrDefault(c => c.CartId == order.CartId);
            var payment = _context.Payments.FirstOrDefault(c => c.OrderId == order.OrderId);
            if (order != null)
            {
                view = (from _order in _context.Order
                        join _cartproduct in _context.CartProducts on _order.CartId equals _cartproduct.CartId //Can remove later
                        join _product in _context.Products on _cartproduct.ProductId equals _product.ProductId
                        join _address in _context.Address on _order.BillingAddressId equals _address.AddressId 
                        join _addres in _context.Address on _order.ShippingAddressId equals _addres.AddressId
                        join _payment in _context.Payments on _order.OrderId equals _payment.OrderId
                        where _order.OrderId == id
                        select new OrderView
                        {
                            OrderId = _order.OrderId,
                            OrderDate = _order.OrderDate,
                            ProductName = _product.ProductName,
                            ProductCount = (int)_cartproduct.CartCount,
                            BillingAddressType = _address.AddressType,
                            BillingAddressHouseNumber = _address.AddressHouseNumber,
                            BillingAddressBuildingName = _address.AddressBuildingName,
                            BillingAddressAreaName = _address.AddressAreaName,
                            BillingAddressCity = _address.City,
                            BillingAddressPincode = _address.Pincode,
                            BillingAddressState = _address.State,
                            ShippingAddressType = _addres.AddressType,
                            ShippingAddressHouseNumber = _addres.AddressHouseNumber,
                            ShippingAddressBuildingName = _addres.AddressBuildingName,
                            ShippingAddressAreaName = _addres.AddressAreaName,
                            ShippingAddressCity = _addres.City,
                            ShippingAddressPincode = _addres.Pincode,
                            ShippingAddressState = _addres.State,
                            TotalPrice = _payment.Paid + _payment.Balance 
                        }).ToList();
            }
            return view;
        }

    }
}
