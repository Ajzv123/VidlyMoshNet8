using System.ComponentModel.DataAnnotations;
using VidlyMoshNet8.Models;

namespace VidlyMoshNet8.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor ingresa un nombre.")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }


        
        public byte MembershipTypeId { get; set; }


        
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}
