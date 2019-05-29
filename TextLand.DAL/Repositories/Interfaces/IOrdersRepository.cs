﻿using System.Collections.Generic;
using TextLand.DAL.Models;

namespace TextLand.DAL.Repositories
{
    public interface IOrdersRepository
    {
        Order AddOrder(Order order);
        List<Order> GetUndoneOrders();
        Order AddTextToOrder(Order order);
        Order GetOrderById(int orderId);
    }
}