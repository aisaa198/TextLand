using TextLand.BL.Models;

namespace TextLand.BL.Services
{
    public interface IUsersService
    {
        UserDto RegisterUser(UserDto userDto);
        UserDto AddExampleUser();
        UserDto GetUserByEmail(string email);
        UserDto GetUserById(int userId);
        bool DeleteUser(int userId, string password);
    }
}