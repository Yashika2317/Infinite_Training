using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Web_Technologies_3.Models;
using Web_Technologies_3.Repositories;

namespace Web_Technologies_3.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IActionResult Index()
        {
            var orders = _orderRepository.GetAllOrders();
            return View(orders);
        }

        public IActionResult OrderDetails(int orderId)
        {
            var order = _orderRepository.GetOrderById(orderId);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        public IActionResult CustomerOrders(string customerId)
        {
            var orders = _orderRepository.GetOrdersByCustomerId(customerId);
            return View(orders);
        }

    }
}
