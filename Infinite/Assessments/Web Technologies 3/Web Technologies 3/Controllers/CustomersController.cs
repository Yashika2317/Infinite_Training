using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Web_Technologies_3.Models;
using Web_Technologies_3.Repositories;

namespace Web_Technologies_3.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            var customers = _customerRepository.GetAllCustomers();
            return View(customers);
        }

        public IActionResult CustomerDetails(string customerId)
        {
            var customer = _customerRepository.GetCustomerById(customerId);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // Additional actions as needed
    }
}
