using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingAppBLL.ModelViews;
using ShoppingAppBLL.Repository.Interfaces;
using ShoppingAppDAL.Models;

namespace ShoppingAppAPI.Controllers
{
    [Route("api/[Controller]")]
    [Produces("application/json")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
        IUserRepository _userRepository;
        private readonly ILogger<ProductController> _logger;
        public UserController(IUserRepository userRepository, ILogger<ProductController> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }
        [HttpGet("GetUserByUserID")]
        [Authorize]
        public User GetUserByID(int id)
        {
            _logger.LogInformation("UserController Excuting ....GetUserByID");
            return _userRepository.GetUserByID(id);
        }
        [HttpPut("UpdateUserData")]
        [Authorize]
        public User UpdateUserById(int id, User users)
        {
            _logger.LogInformation("UserController Excuting ....UpdateUserById");
            return _userRepository.UpdateUserById(id, users);
        }
        [HttpGet("GetAddressByUserId")]
        [Authorize]
        public Address GetAddressUserByID(int id)
        {
            _logger.LogInformation("UserController Excuting ....GetAddressUserByID");
            return _userRepository.GetAddressByUserID(id);
        }
    }
}
