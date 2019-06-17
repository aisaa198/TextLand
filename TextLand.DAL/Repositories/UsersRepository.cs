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

        public bool PayOff(Payoff payoff)
        {
            using (var dbContext = new TextLandDbContext())
            {
                dbContext.Users.Attach(payoff.RequestingUser);
                var newPayoff = dbContext.Payoffs.Add(payoff);
                dbContext.SaveChanges();
                return (newPayoff != null) ? true : false;
            }
        }

        public bool RechargeAccount(int userId, double amount)
        {
            using (var dbContext = new TextLandDbContext())
            {
                var user = GetUserById(userId);
                if (user == null) return false;

                user.AccountForAddingOrders += amount;
                dbContext.Users.Attach(user);
                dbContext.Entry(user).Property(x => x.AccountForAddingOrders).IsModified = true;
                dbContext.SaveChanges();
                return true;
            }
        }

        public User RegisterUser(User user)
        {
            using (var dbContext = new TextLandDbContext())
            {
                var existingUser = GetUserByEmail(user.Email);
                if (existingUser != null) return null;

                var newUser = dbContext.Users.Add(user);
                dbContext.SaveChanges();
                return newUser;
            }
        }

        public double ResetAccount(User user)
        {
            using (var dbContext = new TextLandDbContext())
            {
                dbContext.Users.Attach(user);
                user.AccountForCompletedOrders = 0;
                dbContext.Entry(user).Property(x => x.AccountForCompletedOrders).IsModified = true;
                dbContext.SaveChanges();
                return GetUserById(user.UserId).AccountForCompletedOrders;
            }
        }

        public bool SetAdminPrivilage(int userId)
        {
            using (var dbContext = new TextLandDbContext())
            {
                var user = GetUserById(userId);
                if (user == null) return false;

                user.IsAdmin = true;
                dbContext.Users.Attach(user);
                dbContext.Entry(user).Property(x => x.IsAdmin).IsModified = true;
                dbContext.SaveChanges();

                return (GetUserById(userId).IsAdmin == true) ? true : false;
            }
        }
    }
}
