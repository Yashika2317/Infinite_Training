using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Technologies_3.Models
{
    public class Customers
    {
        [Key]
        [Column("CustomerID")]
        public string CustomerID { get; set; }

        [Column("CompanyName")]
        public string CompanyName { get; set; }

        [Column("ContactName")]
        public string ContactName { get; set; }

    }
}