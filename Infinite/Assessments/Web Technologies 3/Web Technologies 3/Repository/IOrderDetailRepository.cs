using System.Collections.Generic;
using Web_Technologies_3.Models;

namespace Web_Technologies_3.Repositories
{
    public interface IOrderDetailRepository
    {
        OrderDetails GetOrderDetailById(int orderDetailId);
        IEnumerable<OrderDetails> GetAllOrderDetails();
    }
}