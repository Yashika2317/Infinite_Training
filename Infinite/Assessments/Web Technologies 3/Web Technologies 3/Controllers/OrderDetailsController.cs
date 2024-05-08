using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Web_Technologies_3.Models;
using Web_Technologies_3.Repositories;

namespace Web_Technologies_3.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailsController(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public IActionResult Index()
        {
            var orderDetails = _orderDetailRepository.GetAllOrderDetails();
            return View(orderDetails);
        }

        public IActionResult OrderDetailById(int orderDetailId)
        {
            var orderDetail = _orderDetailRepository.GetOrderDetailById(orderDetailId);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return View(orderDetail);
        }

    }
}
