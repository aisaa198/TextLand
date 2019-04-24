using System.Collections.Generic;
using TextLand.BL.Models;

namespace TextLand.BL.Services
{
    public interface IOrdersService
    {
        OrderDto AddExampleOrder();
        OrderDto AddOrder(OrderDto orderDto);
        List<OrderDto> GetUndoneOrders();
    }
}