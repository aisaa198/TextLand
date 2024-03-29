﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TextLand.BL.Models;
using TextLand.BL.Services.Interfaces;
using TextLand.Common;
using TextLand.DAL.Models;
using TextLand.DAL.Repositories.Interfaces;

namespace TextLand.BL.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IMapper _mapper;
        private readonly IOrdersRepository _ordersRepository;
        private readonly IUsersService _usersService;
        private readonly IUsersRepository _usersRepository;
        
        public OrdersService (IMapper mapper, IOrdersRepository ordersRepository, IUsersService usersService, IUsersRepository usersRepository)
        {
            _mapper = mapper;
            _ordersRepository = ordersRepository;
            _usersService = usersService;
            _usersRepository = usersRepository;
        }

        public OrderDto AddExampleOrder()
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
                NumberOfCharacters = 20,
                IsDone = false
            };

            return AddOrder(createdOrder, user.UserId);
        }

        public OrderDto AddOrder(OrderDto orderDto, int userId)
        {
            if (orderDto == null) return null;
            var user = _usersService.GetUserById(userId);
            orderDto.AddingUser = user;
            orderDto.ExecutingUser = null;
            orderDto.IsDone = false;
            orderDto.IsPaid = false;
            orderDto.Content = null;
            
            orderDto.Value = CountValue(orderDto);
            var order = _mapper.Map<Order>(orderDto);
            var addedOrder = _ordersRepository.AddOrder(order);
            return _mapper.Map<OrderDto>(addedOrder);
        }

        public List<OrderDto> GetUndoneOrders()
        {
            return _ordersRepository.GetUndoneOrders().Select(order => _mapper.Map<OrderDto>(order)).ToList();
        }

        public OrderDto AddTextToOrder(int orderId, int executingUserId, string text)
        {
            var order = _ordersRepository.GetOrderById(orderId);
            if (order == null || order.AddingUser.UserId == executingUserId) return null;
            if (order.IsDone == true)
            {
                Console.WriteLine("Order has already done!");
                return null;
            }
            if (text.Length < order.NumberOfCharacters)
            {
                Console.WriteLine("Not enough characters!");
                return null;
            }
            order.Content = text;
            order.IsDone = true;
            order.ExecutingUser = _usersRepository.GetUserById(executingUserId);
            var orderWithText = _ordersRepository.AddTextToOrder(order);

            return _mapper.Map<OrderDto>(orderWithText);
        }

        private double CountValue(OrderDto order)
        {
            if (order == null) return 0;
            double constForText = 0;
            switch (order.TypeOfText)
            {
                case TextType.ProductDescription:
                    constForText = 1.21;
                    break;
                case TextType.Translation:
                    constForText = 3.54;
                    break;
                case TextType.BlogText:
                    constForText = 4.87;
                    break;
                case TextType.SpecialistText:
                    constForText = 8.99;
                    break;
                default:
                    return 0;
            }

            var orderValue = constForText * order.NumberOfCharacters / 1000;
            return orderValue;
        }

        public bool ExportOrder(int orderId, string fileName)
        {
            var serializer = new JsonSerializer();
            try
            {
                var order = _ordersRepository.GetOrderById(orderId);
                return serializer.Export(fileName, order);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public List<OrderDto> GetAddedOrders(int userId)
        {
            if (_usersService.GetUserById(userId) == null) return null;
            return _ordersRepository.GetAddedOrders(userId).Select(order => _mapper.Map<OrderDto>(order)).ToList();
        }

        public bool AcceptOrder(int orderId, int addedUserId)
        {
            var order = _ordersRepository.GetOrderById(orderId);
            if (order == null || order.AddingUser.UserId != addedUserId || order.IsDone == false || order.ExecutingUser == null || order.IsPaid == true) return false;
            return _ordersRepository.AcceptOrder(order);
        }
    }
}
