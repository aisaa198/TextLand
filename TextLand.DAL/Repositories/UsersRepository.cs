using System.Linq;
using TextLand.DAL.Data;
using TextLand.DAL.Models;

namespace TextLand.DAL.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        public User GetUserByEmail(string email)
        {
            using (var dbContext = new TextLandDbContext())
            {
                var user = dbContext.Users.SingleOrDefault(x => x.Email == email);
                return user;
            }
        }

        public User RegisterUser(User user)
        {
            using (var DbContext = new TextLandDbContext())
            {
                var existingUser = GetUserByEmail(user.Email);
                if (existingUser != null) return null;

                var newUser = DbContext.Users.Add(user);
                DbContext.SaveChanges();
                return newUser;
            }
        }
    }
}
