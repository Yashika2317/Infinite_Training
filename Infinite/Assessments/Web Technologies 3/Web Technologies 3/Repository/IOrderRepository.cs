using System;
using System.Collections.Generic;
using Web_Technologies_3.Models;

namespace Web_Technologies_3.Repositories
{
    public interface IOrderRepository
    {
        Orders GetOrderById(int orderId);
        IEnumerable<Orders> GetAllOrders();
        void PlaceOrder(Orders order);
        IEnumerable<Orders> GetOrdersByDate(DateTime orderDate);
        Customers GetCustomerWithHighestOrder();
        IEnumerable<Orders> GetOrdersByCustomerId(string customerId); 
    }
}
