using TextLand.DAL.Models;

namespace TextLand.DAL.Repositories
{
    public interface IUsersRepository
    {
        User GetUserByEmail(string email);
        User RegisterUser(User user);
        User GetUserById(int userId);
        bool DeleteUser(User userToDelete, string password);
    }
}