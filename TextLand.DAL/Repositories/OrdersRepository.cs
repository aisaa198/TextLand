using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TextLand.DAL.Data;
using TextLand.DAL.Models;
using TextLand.DAL.Repositories.Interfaces;

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
                    dbContext.Entry(order.AddingUser).State = EntityState.Modified;
                }

                var newOrder = dbContext.Orders.Add(order);
                dbContext.SaveChanges();
                return newOrder;
            }
        }

        public Order AddTextToOrder(Order madeOrder)
        {
            using (var dbContext = new TextLandDbContext())
            {
                if (madeOrder == null) return null;

                var order = GetOrderById(madeOrder.OrderId);

                dbContext.Orders.Attach(order);
                order.Content = madeOrder.Content;
                order.IsDone = madeOrder.IsDone;
                order.ExecutingUser = madeOrder.ExecutingUser;
                
                //dbContext.Entry(madeOrder.ExecutingUser).State = EntityState.Modified;

                //dbContext.Orders.Attach(madeOrder);
                //dbContext.Entry(madeOrder).Property(x => x.Content).IsModified = true;
                //dbContext.Entry(madeOrder).Property(x => x.IsDone).IsModified = true;
                dbContext.Users.Attach(madeOrder.ExecutingUser);
                dbContext.SaveChanges();

                return GetOrderById(madeOrder.OrderId);
            }
        }

        public List<Order> GetUndoneOrders()
        {
            using (var dbContext = new TextLandDbContext())
            {
                return dbContext.Orders.Where(order => order.IsDone == false).ToList();
            }
        }

        public Order GetOrderById(int orderId)
        {
            using (var dbContext = new TextLandDbContext())
            {
                return dbContext.Orders.Include(x => x.AddingUser).Include(x => x.ExecutingUser).SingleOrDefault(order => order.OrderId == orderId);
            }
        }

        public IEnumerable<object> GetAddedOrders(int userId)
        {
            using (var dbContext = new TextLandDbContext())
            {
                return dbContext.Orders.Where(x => x.AddingUser.UserId == userId).ToList();
            }
        }
    }
}
