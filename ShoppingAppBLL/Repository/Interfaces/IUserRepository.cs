using ShoppingAppDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppBLL.Repository.Interfaces
{
    public interface IUserRepository
    {
        public User GetUserByID(int id); //get User by its id
        public User UpdateUserById(int id, User users); //update User details
        public Address GetAddressByUserID(int id);
    }
}
