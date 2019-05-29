using System.Collections.Generic;
using TextLand.BL.Models;

namespace TextLand.BL.Services.Interfaces
{
    public interface IOrdersService
    {
        OrderDto AddExampleOrder();
        OrderDto AddOrder(OrderDto orderDto);
        List<OrderDto> GetUndoneOrders();
        OrderDto AddTextToOrder(int orderId, string text);
        bool ExportOrder(int orderId, string fileName);
    }
}