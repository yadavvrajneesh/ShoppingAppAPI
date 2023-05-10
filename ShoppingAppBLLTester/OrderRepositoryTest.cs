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
    public class OrderRepositoryTest
    {
        DataBaseContext db;
        List<Order> orders;
        List<User> users;
        OrderRepository orderRepository;
        UserRepository userRepository;
        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataBaseContext>()
           .UseInMemoryDatabase(databaseName: "ShoppingApp")
           .Options;
            db = new DataBaseContext(options);
            orders = new List<Order>()
            {
                new Order {OrderId = 1, OrderDate = DateTime.Now, OrderPrice = 500, CartId=1, BillingAddressId=1, ShippingAddressId = 1, UserId =1},
            };
            users = new List<User>()
            {
                new User(){UserId=1,UserFName="Jay", UserLName="Modi",UserContact="9999999999",UserEmail="modi@gmail.com"},
                new User(){UserId=2,UserFName="Rajneesh", UserLName="Yadav",UserContact="8888888888",UserEmail="yrajneesh@gmail.com"},
                new User(){UserId=3,UserFName="Sam", UserLName="Sandhu",UserContact="7777777777",UserEmail="sandhu@gmail.com"},

            };
            db.Users.AddRange(users);
            db.SaveChanges();
            db.Order.AddRange(orders);
            db.SaveChanges();
            orderRepository = new OrderRepository(db);
            userRepository = new UserRepository(db);
        }
        [OneTimeTearDown]
        public void CleanUp()
        {
            db.Order.RemoveRange(orders);
            db.SaveChanges();
            db.Dispose();
        }
        [Test]
        [Order(1)]
        public void AddOrderTest()
        {
            var entity = orderRepository.AddOrder(1, 1, 1, "UPI");
            var entity1 = orderRepository.ViewOrdersByOrderID(1);

        }
    }
}
