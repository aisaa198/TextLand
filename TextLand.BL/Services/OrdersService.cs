using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using TextLand.BL.Models;
using TextLand.DAL.Models;
using TextLand.DAL.Repositories;

namespace TextLand.BL.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IMapper _mapper;
        private readonly IOrdersRepository _ordersRepository;
        private readonly IUsersService _usersService;
        
        public OrdersService (IMapper mapper, IOrdersRepository ordersRepository, IUsersService usersService)
        {
            _mapper = mapper;
            _ordersRepository = ordersRepository;
            _usersService = usersService;
        }

        private OrderDto CreateExampleOrder()
        {
            var user = _usersService.GetUserByEmail("mariann@gmail.com") ?? _usersService.AddExampleUser();
            var createdOrder = new OrderDto
            {
                TypeOfText = Common.TextType.BlogText,
                KeyWords = new List<string>
                {
                    "szkoła",
                    "przedszkole"
                },
                NumberOfCharacters = 2000,
                AddingUser = user,
                Status = false
            };

            return createdOrder;
        }

        public OrderDto AddExampleOrder()
        {
            var exampleOrder = CreateExampleOrder();
            return AddOrder(exampleOrder);
        }

        public OrderDto AddOrder(OrderDto orderDto)
        {
            if (orderDto == null) return null;
            var order = _mapper.Map<Order>(orderDto);
            var addedOrder = _ordersRepository.AddOrder(order);
            return _mapper.Map<OrderDto>(addedOrder);
        }

        public List<OrderDto> GetUndoneOrders()
        {
            return _ordersRepository.GetUndoneOrders().Select(order => _mapper.Map<OrderDto>(order)).ToList();
        }
    }
}
