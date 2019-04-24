using System.Collections.Generic;
using System.Linq;
using TextLand.DAL.Data;
using TextLand.DAL.Models;

namespace TextLand.DAL.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        public Order AddOrder(Order order)
        {
            using (var dbContext = new TextLandDbContext())
            {
                if (order.AddingUser != null && !dbContext.Users.Local.Contains(order.AddingUser))
                {
                    dbContext.Users.Attach(order.AddingUser);
                    dbContext.Entry(order.AddingUser).State = System.Data.Entity.EntityState.Modified;
                }

                var newOrder = dbContext.Orders.Add(order);
                dbContext.SaveChanges();
                return newOrder;
            }
            


        }

        public List<Order> GetUndoneOrders()
        {
            using (var dbContext = new TextLandDbContext())
            {
                return dbContext.Orders.Where(order => order.Status == false).ToList();
            }
        }
    }
}
