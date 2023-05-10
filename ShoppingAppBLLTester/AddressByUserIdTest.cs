using Microsoft.EntityFrameworkCore;
using ShoppingAppBLL.Repository.Classes;
using ShoppingAppDAL.Context;
using ShoppingAppDAL.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingAppBLLTester
{
    public class AddressByUserIdTest
    {/// <summary>
     /// UserRepositoryTests uses NUintTesting.
     /// </summary>
        DataBaseContext db;
        List<Address> addresses;
        UserRepository userRepo;
        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataBaseContext>()
           .UseInMemoryDatabase(databaseName: "ShoppingApp")
           .Options;
            db = new DataBaseContext(options);
            addresses = new List<Address>()
            {
                new Address(){AddressId=1,AddressHouseNumber=5, AddressBuildingName="Sadan",AddressAreaName="Dayalpur",AddressType="Home", City="Delhi", State="Delhi", Pincode=110094,UserId=1},
                new Address(){AddressId=2,AddressHouseNumber=9, AddressBuildingName="Niwas",AddressAreaName="Karawal Nagar",AddressType="Home", City="Delhi", State="Delhi", Pincode=110094,UserId=1},
                new Address(){AddressId=3,AddressHouseNumber=1, AddressBuildingName="Bhavan",AddressAreaName="Kasmere Gate",AddressType="Home", City="Delhi", State="Delhi", Pincode=110094,UserId=1},

            };
            db.Address.AddRange(addresses);
            db.SaveChanges();
            userRepo = new UserRepository(db);
        }
        [Test]
        [Order(1)]
        public void GetAddressByUserIDTest()
        {

            int id = 1;
            var entity = userRepo.GetAddressByUserID(id);

            Assert.NotNull(entity);
            Assert.AreEqual(1, entity.AddressId);
            Assert.AreEqual(5, entity.AddressHouseNumber);
            Assert.That(entity.AddressBuildingName, Is.EqualTo("Sadan"));
            Assert.AreEqual("Dayalpur", entity.AddressAreaName);
            Assert.AreEqual("Home", entity.AddressType);
            Assert.AreEqual("Delhi", entity.City);
            Assert.AreEqual("Delhi", entity.State);
            Assert.AreEqual(110094, entity.Pincode);
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            db.Dispose();
        }
    }
}