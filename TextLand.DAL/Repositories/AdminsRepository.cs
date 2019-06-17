using System.Collections.Generic;
using System.Linq;
using TextLand.DAL.Data;
using TextLand.DAL.Models;
using TextLand.DAL.Repositories.Interfaces;
using System.Data.Entity;

namespace TextLand.DAL.Repositories
{
    public class AdminsRepository : IAdminsRepository
    {
        public Payoff RealizePayoff(int id)
        {
            using (var dbContext = new TextLandDbContext())
            {
                var payoffToRealize =  GetUndonePayoffs().SingleOrDefault(x => x.PayoffId == id);
                if (payoffToRealize == null) return null;

                dbContext.Payoffs.Attach(payoffToRealize);
                payoffToRealize.IsDone = true;
                dbContext.SaveChanges();

                return GetPayoffById(id);
            }
        }

        private Payoff GetPayoffById(int id)
        {
            using (var dbContext = new TextLandDbContext())
            {
                return dbContext.Payoffs.Include(x => x.RequestingUser).SingleOrDefault(x => x.PayoffId == id);
            }
        }

        public List<Payoff> GetUndonePayoffs()
        {
            using(var dbContext = new TextLandDbContext())
            {
                return dbContext.Payoffs.Include(x => x.RequestingUser).Where(x => x.IsDone == false).ToList();
            }
        }
    }
}
