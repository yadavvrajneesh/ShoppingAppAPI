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
    public class ProductRepository : IProductRepository
    {
        DataBaseContext _context;
        Product _product;
        Category _category;
        public ProductRepository(DataBaseContext context)
        {
            _context = context;
            _product = new Product();
            _category = new Category();
        }

        public IEnumerable<ProductView> GetAllProducts()
        {
            return _context.Products.Select(products =>

                new ProductView
                {
                    ProductName = products.ProductName,
                    ProductDescription = products.ProductDescription,
                    ProductPrice = products.ProductPrice
                }
            ).ToList();
        }

        public List<ProductView> GetProductByCategoryName(string categoryname)
        {
            var category = _context.Categories.Where(c => c.CategoryName == categoryname).FirstOrDefault();

            return _context.Products.Where(p => p.CategoryId == category.CategoryId).Select(product =>
                new ProductView
                {
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    ProductPrice = product.ProductPrice,
                }
            ).ToList();
        }
    }
}
