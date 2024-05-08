using System.Collections.Generic;
using Web_Technologies_3.Models;

namespace Web_Technologies_3.Repositories
{
    public interface ICustomerRepository
    {
        Customers GetCustomerById(string customerId);
        IEnumerable<Customers> GetAllCustomers();
    }
}