using System.Linq;
using TextLand.DAL.Data;
using TextLand.DAL.Models;
using TextLand.DAL.Repositories.Interfaces;

namespace TextLand.DAL.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        public User ChangeUserData(User changedUser)
        {
            using (var dbContext = new TextLandDbContext())
            {
                var modifyingUser = GetUserById(changedUser.UserId);
                if (modifyingUser == null) return null;

                dbContext.Users.Attach(modifyingUser);
                dbContext.Entry(modifyingUser).CurrentValues.SetValues(changedUser);
                dbContext.SaveChanges();

                var newUser = GetUserById(changedUser.UserId);
                return newUser;
            }
        }

        public bool DeleteUser(User userToDelete, string password)
        {
            using (var dbContext = new TextLandDbContext())
            {
                dbContext.Users.Attach(userToDelete);
                dbContext.Users.Remove(userToDelete);
                dbContext.SaveChanges();
                return (GetUserById(userToDelete.UserId) == null)? true : false;
            }
        }

        public User GetUserByEmail(string email)
        {
            using (var dbContext = new TextLandDbContext())
            {
                var user = dbContext.Users.SingleOrDefault(x => x.Email == email);
                return user;
            }
        }

        public User GetUserById(int userId)
        {
            using (var dbContext = new TextLandDbContext())
            {
                var user = dbContext.Users.SingleOrDefault(x => x.UserId == userId);
                return user;
            }
        }

        public User LogIn(string email, string password)
        {
            using (var dbContext = new TextLandDbContext())
            {
                var user = dbContext.Users.SingleOrDefault(x => x.Email == email);
                return (user != null && user.Password == password) ? user : null;
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
