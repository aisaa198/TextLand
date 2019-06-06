using TextLand.DAL.Models;

namespace TextLand.DAL.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        User GetUserByEmail(string email);
        User RegisterUser(User user);
        User GetUserById(int userId);
        bool DeleteUser(User userToDelete, string password);
        User LogIn(string email, string password);
        User ChangeUserData(User changedUser);
        bool SetAdminPrivilage(int userId);
    }
}