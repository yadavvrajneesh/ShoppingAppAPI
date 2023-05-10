using Microsoft.EntityFrameworkCore;
using ShoppingAppBLL.Repository.Classes;
using ShoppingAppDAL.Context;
using ShoppingAppDAL.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingAppBLLTester
{
    public class UserRepositoryTest
    {/// <summary>
     /// UserRepositoryTests uses NUintTesting.
     /// </summary>
        DataBaseContext db;
        List<User> users;
        UserRepository userRepo;
        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataBaseContext>()
           .UseInMemoryDatabase(databaseName: "ShoppingApp")
           .Options;
            db = new DataBaseContext(options);
            users = new List<User>()
            {
                new User(){UserId=1,UserFName="Jay", UserLName="Modi",UserContact="9999999999",UserEmail="modi@gmail.com"},
                new User(){UserId=2,UserFName="Rajneesh", UserLName="Yadav",UserContact="8888888888",UserEmail="yrajneesh@gmail.com"},
                new User(){UserId=3,UserFName="Sam", UserLName="Sandhu",UserContact="7777777777",UserEmail="sandhu@gmail.com"},

            };
            db.Users.AddRange(users);
            db.SaveChanges();
            userRepo = new UserRepository(db);
        }
       
        [Test]
        [Order(1)]
        public void GetUserByIDTest()
        {

            int id = 2;
            var entity = userRepo.GetUserByID(id);

            Assert.NotNull(entity);
            Assert.AreEqual(2, entity.UserId);
            Assert.AreEqual("Rajneesh", entity.UserFName);
            Assert.AreEqual("Yadav", entity.UserLName);
            Assert.AreEqual("8888888888", entity.UserContact);
            Assert.AreEqual("yrajneesh@gmail.com", entity.UserEmail);

        }

        [Test]
        [Order(2)]
        public void UpdateUserByIDTest()
        {
            int id = 1;
            User user = new User() { UserId = 1, UserFName = "Jay", UserLName = "Modi", UserContact = "8899999999", UserEmail = "modi@gmail.com" };
            var entity = userRepo.UpdateUserById(id, user);
            Assert.NotNull(entity);

            Assert.AreEqual("8899999999", entity.UserContact);

        }
        [OneTimeTearDown]
        public void cleanup()
        {
            db.Dispose();
        }
    }
}