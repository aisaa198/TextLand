using System.Collections.Generic;
using System.Web.Http;
using TextLand.BL.Models;
using TextLand.BL.Services;

namespace TextLand.Controllers
{
    public class OrdersController : ApiController
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [Route("api/orders/WriteText")]
        public OrderDto PostExampleOrder()
        {
            return _ordersService.AddExampleOrder();
        }
        
        public List<OrderDto> GetUndoneOrders()
        {
            return _ordersService.GetUndoneOrders();
        }

        [HttpPut]
        [Route("api/orders/WriteText")]
        public OrderDto WriteText(int orderId, string text)
        {
            return _ordersService.AddTextToOrder(orderId, text);
        }
    }
}
