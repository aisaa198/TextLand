using TextLand.DAL.Models;

namespace TextLand.DAL.Repositories
{
    public interface IUsersRepository
    {
        User GetUserByEmail(string email);
        User RegisterUser(User user);
    }
}