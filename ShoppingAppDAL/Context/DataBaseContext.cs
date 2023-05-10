using Microsoft.EntityFrameworkCore;
using ShoppingAppDAL.Models;
using ShoppingAppDAL.Models.Shopping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppDAL.Context
{
    /// <summary>
    /// This is DataBaseContext that uses DbContext and has all the DbSets for ShoppingApp
    /// </summary>
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<CartProducts> CartProducts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Address> Address { get; set; }
    }
}
