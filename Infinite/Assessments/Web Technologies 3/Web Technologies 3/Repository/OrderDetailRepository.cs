using System.Collections.Generic;
using System.Linq;
using Web_Technologies_3.Models;

namespace Web_Technologies_3.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly NorthwindContext _context;

        public OrderDetailRepository(NorthwindContext context)
        {
            _context = context;
        }

        public OrderDetails GetOrderDetailById(int orderDetailId)
        {
            return _context.OrderDetails.FirstOrDefault(od => od.OrderDetailID == orderDetailId);
        }

        public IEnumerable<OrderDetails> GetAllOrderDetails()
        {
            return _context.OrderDetails.ToList();
        }

        
    }
}