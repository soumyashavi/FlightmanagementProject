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
    using System.ComponentModel.DataAnnotations;
    
    public partial class Registration
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Registration()
        {
            this.Booking2 = new HashSet<Booking2>();
        }
    
        public int UserId { get; set; }
        [Required(ErrorMessage ="User name required")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="EmailId Required")]
        [EmailAddress(ErrorMessage ="Invalid EmailId")]
        public string EmailId { get; set; }
        [DataType(DataType.Password)]
        [MinLength(8,ErrorMessage ="Password should be minimum 8 characters")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public string Gender { get; set; }
        [RegularExpression(@"([0-9]{10})$",ErrorMessage ="Invalid MobileNumber")]
        public Nullable<long> MobileNumber { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking2> Booking2 { get; set; }
    }
}
