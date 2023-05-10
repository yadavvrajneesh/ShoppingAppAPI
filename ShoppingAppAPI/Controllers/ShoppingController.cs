using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingAppBLL.ModelViews;
using ShoppingAppBLL.Repository.Interfaces;
using ShoppingAppDAL.Models;
using System.Runtime.InteropServices;

namespace ShoppingAppAPI.Controllers
{
    [Route("api/[Controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        ICartRepository _cartRepository;
        ICartProductRepository _cartProdRepository;
        IOrderRepository _orderRepository;
        private readonly ILogger<ProductController> _logger;
        public ShoppingController(ICartRepository cartRepository, ICartProductRepository cartProdRepository, IOrderRepository orderRepository, ILogger<ProductController> logger)
        {
            _cartRepository = cartRepository;
            _cartProdRepository = cartProdRepository;
            _orderRepository = orderRepository;
            _logger = logger;
        }
        [HttpGet("GetCartByUserId")]
        [Authorize]
        public List<CartProductView> GetCartItemsyByUserID(int id)
        {
            _logger.LogInformation("ShoppingController Excuting ....GetCartItemsyByUserID");
            return _cartRepository.GetCartItemsyByUserID(id);
        }
        [HttpPut("AddToCart")]
        [Authorize]
        public List<CartProductView> AddProductInCart(int userid, int productid, int cartcount)
        {
            _logger.LogInformation("ShoppingController Excuting ....AddProductInCart");
            return _cartProdRepository.AddProductInCart(userid, productid, cartcount);
        }
        [HttpPut("RemoveFromCart")]
        [Authorize]
        public List<CartProductView> RemoveProductsInCart(int userid, int productid, int cartcount)
        {
            _logger.LogInformation("ShoppingController Excuting ....RemoveProductsInCart");
            return _cartProdRepository.RemoveProductsInCart(userid, productid, cartcount);
        }
        [HttpPost("AddOrder")]
        [Authorize]
        public Order AddOrder(int userId, int BillingAddressId, int shippingAddressId, string mode)
        {
            _logger.LogInformation("ShoppingController Excuting ....AddOrder");
            return _orderRepository.AddOrder(userId, BillingAddressId, shippingAddressId, mode);
        }
        [HttpGet("OrderByOrderId")]
        [Authorize]
        public List<OrderView> ViewOrdersByOrderID(int id)
        {
            _logger.LogInformation("ShoppingController Excuting ....ViewOrdersByOrderID");
            return _orderRepository.ViewOrdersByOrderID(id);
        }
    }
}
