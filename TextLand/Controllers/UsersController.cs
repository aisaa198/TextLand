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

        [HttpGet]
        [Route("api/users/addExampleUser")]
        public UserDto AddExampleUser()
        {
            return _usersService.AddExampleUser();
        }
    }
}
