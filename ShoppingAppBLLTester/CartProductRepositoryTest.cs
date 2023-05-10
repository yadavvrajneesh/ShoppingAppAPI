using Microsoft.EntityFrameworkCore;
using ShoppingAppBLL.Repository.Classes;
using ShoppingAppBLL.Repository.Interfaces;
using ShoppingAppDAL.Context;
using ShoppingAppDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppBLLTester
{
    public class CartProductRepositoryTest
    {
        DataBaseContext db;
        List<Cart> cart;
        List<CartProducts> cartProduct;
        List<Product> products;

        ICartRepository cartRepository;
        CartProductRepository cartproductrepo;

        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataBaseContext>()
           .UseInMemoryDatabase(databaseName: "ShoppingApp")
           .Options;
            db = new DataBaseContext(options);
            cart = new List<Cart>()
            {
                new Cart(){CartId=1 ,UserId=1, CartPrice= 100},
                new Cart(){CartId=2 ,UserId=2, CartPrice= 200},
                new Cart(){CartId=3 ,UserId=3, CartPrice= 300}
            };
            products = new List<Product>()
            {
                new Product(){ProductId = 1, ProductName = "PRODUCT 1", ProductDescription = "THIS IS PRODUCT 1", ProductPrice=393 ,ProductCount =8 , CategoryId = 1},
                new Product(){ProductId = 2, ProductName = "PRODUCT 2", ProductDescription = "THIS IS PRODUCT 2", ProductPrice=393 ,ProductCount =8 , CategoryId = 2},
                new Product(){ProductId = 3, ProductName = "PRODUCT 3", ProductDescription = "THIS IS PRODUCT 3", ProductPrice=393 ,ProductCount =8 , CategoryId = 3}

            };
            cartProduct = new List<CartProducts>()
            {
                new CartProducts(){CartProductId = 1, CartId=1 ,ProductId = 1, CartCount = 2},
                new CartProducts(){CartProductId = 2, CartId=2 ,ProductId = 2, CartCount = 2},
                new CartProducts(){CartProductId = 3, CartId=3 ,ProductId = 3, CartCount = 4}
            };

            db.Cart.AddRange(cart);
            db.Products.AddRange(products);
            db.CartProducts.AddRange(cartProduct);
            db.SaveChanges();

            cartRepository = new CartRepository(db);
            cartproductrepo = new CartProductRepository(db, cartRepository);

        }
        [OneTimeTearDown]

        public void CleanUp()
        {
            db.Cart.RemoveRange(cart);
            db.Products.RemoveRange(products);
            db.CartProducts.RemoveRange(cartProduct);
            db.SaveChanges();
            db.Dispose();
        }
        [Test]
        [Order(1)]
        public void AddProductsInCart_Test()
        {
            int userid = 2;
            int productid = 2;
            int cartcount = 1;
            var entity = cartproductrepo.AddProductInCart(userid, productid, cartcount);
            var entity1 = entity.Where(p => p.ProductId == productid).Select(p => p.CartCount).FirstOrDefault();
            Assert.NotNull(entity);
            Assert.AreEqual(3, entity1);
        }
        [Test]
        [Order(2)]
        public void RemoveProductsInCart_Test()
        {
            int userid = 2;
            int productid = 2;

            int cartcount = 1;
            var entity = cartproductrepo.RemoveProductsInCart(userid, productid, cartcount);
            var entity1 = entity.Where(p => p.ProductId == productid).Select(p => p.CartCount).FirstOrDefault();
            Assert.NotNull(entity);
            Assert.AreEqual(2, entity1);
        }
    }
}

