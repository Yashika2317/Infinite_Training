using System.Collections.Generic;
using System.Linq;
using Web_Technologies_3.Models;

namespace Web_Technologies_3.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly NorthwindContext _context;

        public CustomerRepository(NorthwindContext context)
        {
            _context = context;
        }

        public Customers GetCustomerById(string customerId)
        {
            return _context.Customers.FirstOrDefault(c => c.CustomerID == customerId);
        }

        public IEnumerable<Customers> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

    }
}