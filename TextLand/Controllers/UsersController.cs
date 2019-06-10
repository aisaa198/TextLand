using System.Web.Http;
using TextLand.BL.Models;
using TextLand.BL.Services.Interfaces;

namespace TextLand.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        
        [HttpPost]
        [Route("api/users/AddExampleUser")]
        public UserDto AddExampleUser()
        {
            return _usersService.AddExampleUser();
        }

        [HttpPost]
        [Route("api/users/RegisterUser")]
        public UserDto RegisterUser(UserDto newUserDto)
        {
            return _usersService.RegisterUser(newUserDto);
        }

        [HttpGet]
        [Route("api/users/GetUserById")]
        public UserDto GetUserById(int userId)
        {
            return _usersService.GetUserById(userId);
        }

        [HttpGet]
        [Route("api/users/LogIn")]
        public UserDto LogIn(string email, string password)
        {
            return _usersService.LogIn(email, password);
        }

        [HttpPut]
        [Route("api/users/RechargeAccount")]
        public bool RechargeAccount(int userId, decimal amount)
        {
            return _usersService.RechargeAccount(userId, amount);
        }

        [HttpPut]
        [Route("api/users/ChangeUserData")]
        public UserDto ChangeUserData (UserDto changedUserDto)
        {
            return _usersService.ChangeUserData(changedUserDto);
        }

        public bool DeleteUser(int userId, string password)
        {
            return _usersService.DeleteUser(userId, password);
        }

        [HttpPut]
        [Route("api/users/SetAdminPrivilage")]
        public bool SetAdminPrivilage(int userId)
        {
            return _usersService.SetAdminPrivilage(userId);
        }
    }
}
