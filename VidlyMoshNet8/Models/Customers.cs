using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyMoshNet8.Models
{
    public class Customers
    {
        public int Id { get; set; }
        
        [Required (ErrorMessage = "Por favor ingresa un nombre.")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        
        public MembershipType MembershipType { get; set; }
        
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
        
        
        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
        
    }
}
