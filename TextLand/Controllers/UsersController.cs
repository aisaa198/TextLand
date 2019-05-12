using System.Web.Http;
using TextLand.BL.Models;
using TextLand.BL.Services;

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
        
        public UserDto GetUserById(int userId)
        {
            return _usersService.GetUserById(userId);
        }

        public bool DeleteUser(int userId, string password)
        {
            return _usersService.DeleteUser(userId, password);
        }
    }
}
