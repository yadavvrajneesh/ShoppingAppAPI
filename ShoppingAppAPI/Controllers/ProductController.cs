using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingAppBLL.ModelViews;
using ShoppingAppBLL.Repository.Interfaces;
using System.Collections.Generic;

namespace ShoppingAppAPI.Controllers
{
    [Route("api/[Controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductRepository iprodrep;
        private readonly ILogger<ProductController> _logger;
        public ProductController(IProductRepository ipr, ILogger<ProductController> logger)
        {
            iprodrep = ipr;
            _logger = logger;
        }//get all products
        [HttpGet("GetAllProducts")]
        [Authorize]
        public IEnumerable<ProductView> GetAllProducts()
        {
            _logger.LogInformation("ProductController Excuting ....GetAllProducts");
            try
            {
                return iprodrep.GetAllProducts();
            }
            catch (Exception )
            {
                return Enumerable.Empty<ProductView>();
            }
            
        }
        [HttpGet("ProductsByCategory")]
        [Authorize]
        public List<ProductView> GetProductByCategoryName(string categoryname)
        {
            _logger.LogInformation("ProductController Excuting ....GetProductByCategoryName");
            return iprodrep.GetProductByCategoryName(categoryname);     
        }
    }
}
