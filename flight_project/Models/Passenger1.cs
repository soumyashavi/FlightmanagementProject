//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace flight_project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Passenger1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Passenger1()
        {
            this.Booking2 = new HashSet<Booking2>();
        }
    
        public int PassengerId { get; set; }
        public Nullable<int> PassengerAge { get; set; }
        public Nullable<int> PassengerCount { get; set; }
        public Nullable<long> PassengerUIN { get; set; }
        public Nullable<int> Luggages { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking2> Booking2 { get; set; }
    }
}
