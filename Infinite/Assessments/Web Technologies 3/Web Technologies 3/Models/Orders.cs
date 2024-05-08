using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Technologies_3.Models
{
    public class Orders
    {
        [Key]
        [Column("OrderID")]
        public int OrderID { get; set; }

        [Column("OrderDate")]
        public DateTime OrderDate { get; set; }
        public object CustomerID { get; internal set; }
        public object CustomerId { get; internal set; }
        public decimal Total { get; internal set; }

    }
}