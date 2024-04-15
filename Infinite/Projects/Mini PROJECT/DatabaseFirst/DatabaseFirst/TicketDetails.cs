using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst
{
    
    public class TicketDetails
    {
        public int Train_no { get; set; }
        public string Source_loc { get; set; }
        public string Destination { get; set; }
        public int Total_Fare { get; set; }
        public int Refund_Amount { get; set; }

    }

}
