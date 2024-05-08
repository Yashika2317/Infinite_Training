using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Technologies_3.Models
{
    public class OrderDetails
    {
        [Key]
        [Column("OrderDetailID")]
        public int OrderDetailID { get; set; }

        [Column("OrderID")]
        public int OrderID { get; set; }

        [Column("ProductID")]
        public int ProductID { get; set; }

        [Column("Quantity")]
        public int Quantity { get; set; }

    }
}