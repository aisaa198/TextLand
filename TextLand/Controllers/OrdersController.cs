using System.Collections.Generic;
using System.Web.Http;
using TextLand.BL.Models;
using TextLand.BL.Services.Interfaces;

namespace TextLand.Controllers
{
    public class OrdersController : ApiController
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [Route("api/orders/PostExampleOrder")]
        public OrderDto PostExampleOrder()
        {
            return _ordersService.AddExampleOrder();
        }

        [Route("api/orders/PostOrder")]
        public OrderDto PostOrder(OrderDto newOrder, int userId)
        {
            return _ordersService.AddOrder(newOrder, userId);
        }

        [Route("api/orders/GetUndoneOrders")]
        public List<OrderDto> GetUndoneOrders()
        {
            return _ordersService.GetUndoneOrders();
        }

        [HttpGet]
        [Route("api/orders/ExportOrder")]
        public bool ExportOrder(int orderId, string fileName)
        {
            return _ordersService.ExportOrder(orderId, fileName);
        }

        [HttpPut]
        [Route("api/orders/WriteText")]
        public OrderDto WriteText(int orderId, int executingUserId, string text)
        {
            return _ordersService.AddTextToOrder(orderId, executingUserId, text);
        }
    }
}