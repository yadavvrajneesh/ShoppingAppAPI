using Microsoft.EntityFrameworkCore;
using ShoppingAppBLL.ModelViews;
using ShoppingAppBLL.Repository.Classes;
using ShoppingAppDAL.Context;
using ShoppingAppDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppBLLTester
{
    public class ProductRepositoryTest
    {
        DataBaseContext db;
        List<Product> products;
        List<Category> categories;
        ProductRepository productRepository;
        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataBaseContext>()
           .UseInMemoryDatabase(databaseName: "ShoppingApp")
           .Options;
            db = new DataBaseContext(options);
            products = new List<Product>()
            {
                new Product() { ProductId = 1, ProductName = "TEST PRODUCT 1", ProductDescription = "THIS IS TEST PRODUCT 1", ProductPrice = 100, ProductCount= 2, CategoryId = 1 },
                new Product() { ProductId = 2, ProductName = "TEST PRODUCT 2", ProductDescription = "THIS IS TEST PRODUCT 2", ProductPrice = 200, ProductCount= 4, CategoryId = 2 },
                new Product() { ProductId = 3, ProductName = "TEST PRODUCT 3", ProductDescription = "THIS IS TEST PRODUCT 3", ProductPrice = 300, ProductCount= 8, CategoryId = 3 },
            };
            categories = new List<Category>()
            {
                new Category() { CategoryId = 1, CategoryName="Electronics"},
                new Category() { CategoryId = 2, CategoryName="Personal care"}
            };
            db.Products.AddRange(products);
            db.SaveChanges();
            db.Categories.AddRange(categories);
            db.SaveChanges();
            productRepository = new ProductRepository(db);
        }
        [OneTimeTearDown]
        public void CleanUp()
        {
            db.Products.RemoveRange(products);
            db.SaveChanges();
            db.Dispose();
        }
        [Test]
        [Order(1)]
        public void GetAllProductsTest()
        {
            var entity = productRepository.GetAllProducts();
            Assert.AreEqual(3, entity.Count());
        }
        [Test]
        [Order(2)]
        public void GetProductsByCategoryNameTest()
        {
            string categoryName = "Electronics";
            var entity = productRepository.GetProductByCategoryName(categoryName);
            Assert.NotNull(entity);
            Assert.AreEqual(1, entity.Count);
           // var category = db.Categories.Where(c => c.CategoryName == categoryName).FirstOrDefault();
           // return db.Products.Where(p => p.CategoryId == category.CategoryId).Select(product =>
           //    new ProductView
           //    {
           //        ProductName = product.ProductName,
           //        ProductDescription = product.ProductDescription,
           //        ProductPrice = product.ProductPrice,
           //    }
           //).ToList();

        }
    }
}
