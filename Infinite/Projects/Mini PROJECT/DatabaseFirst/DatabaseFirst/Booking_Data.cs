//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class Booking_Data
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Booking_Data()
        {
            this.Cancellation_Data = new HashSet<Cancellation_Data>();
        }
    
        public int Book_ID { get; set; }
        public string UserName { get; set; }
        public Nullable<int> Train_no { get; set; }
        public string Class { get; set; }
        public Nullable<System.DateTime> Booking_Date { get; set; }
        public Nullable<int> No_of_Tickets { get; set; }
        public Nullable<int> Total_Fare { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cancellation_Data> Cancellation_Data { get; set; }
        public virtual Train Train { get; set; }
    }
}
