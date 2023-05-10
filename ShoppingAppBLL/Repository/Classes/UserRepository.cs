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
    public class UserRepository : IUserRepository
    {
        DataBaseContext _context;
        public UserRepository(DataBaseContext dataBaseContext)
        {
              _context= dataBaseContext;
        }
        public User GetUserByID(int id)
        {
            return _context.Users.Find(id);
        }

        public User UpdateUserById(int id, User users)
        {
            var user = _context.Users.FirstOrDefault(c => c.UserId == id); //check if id exists and only then update it
            if (user != null)
            {
                _context.Entry<User>(user).CurrentValues.SetValues(users);
                _context.SaveChanges();
            }
            return user;
        }
        public Address GetAddressByUserID(int id)
        {
            return _context.Address.Find(id);
        }
    }
}
