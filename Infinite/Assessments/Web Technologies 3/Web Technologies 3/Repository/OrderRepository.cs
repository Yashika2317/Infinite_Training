using System;
using System.Collections.Generic;
using System.Linq;
using Web_Technologies_3.Models;

namespace Web_Technologies_3.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly NorthwindContext _context;

        public OrderRepository(NorthwindContext context)
        {
            _context = context;
        }

        public Orders GetOrderById(int orderId)
        {
            return _context.Orders.FirstOrDefault(o => o.OrderID == orderId);
        }

        public IEnumerable<Orders> GetAllOrders()
        {
            return _context.Orders.ToList();
        }

        public void PlaceOrder(Orders order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public IEnumerable<Orders> GetOrdersByDate(DateTime orderDate)
        {
            return _context.Orders.Where(o => o.OrderDate.Date == orderDate.Date).ToList();
        }

        public Customers GetCustomerWithHighestOrder()
        {
            var customerIdWithHighestOrder = _context.Orders
                .GroupBy(o => o.CustomerID)
                .Select(g => new { CustomerId = g.Key, TotalOrderAmount = g.Sum(o => o.Total) })
                .OrderByDescending(x => x.TotalOrderAmount)
                .FirstOrDefault()?.CustomerId;

            if (customerIdWithHighestOrder == null)
            {
                return null;
            }

            return _context.Customers.FirstOrDefault(c => c.CustomerID == customerIdWithHighestOrder);
        }

        public IEnumerable<Orders> GetOrdersByCustomerId(string customerId)
        {
            return _context.Orders.Where(o => o.CustomerID == customerId).ToList();
        }
    }
}
