using TextLand.BL.Models;

namespace TextLand.BL.Services.Interfaces
{
    public interface IUsersService
    {
        UserDto RegisterUser(UserDto userDto);
        UserDto AddExampleUser();
        UserDto GetUserByEmail(string email);
        UserDto GetUserById(int userId);
        bool DeleteUser(int userId, string password);
        UserDto LogIn(string login, string password);
        UserDto ChangeUserData(UserDto changedUserDto);
    }
}