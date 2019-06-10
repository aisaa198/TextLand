using System.Collections.Generic;
using TextLand.BL.Models;

namespace TextLand.BL.Services.Interfaces
{
    public interface IOrdersService
    {
        OrderDto AddExampleOrder();
        List<OrderDto> GetUndoneOrders();
        OrderDto AddTextToOrder(int orderId, int executingUserId, string text);
        bool ExportOrder(int orderId, string fileName);
        OrderDto AddOrder(OrderDto newOrder, int userId);
        List<OrderDto> GetAddedOrders(int userId);
    }
}