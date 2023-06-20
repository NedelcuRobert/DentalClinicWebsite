using System.ComponentModel.DataAnnotations;

namespace DentalClinicWebsite.Models.DTOs
{
    public class ServiceDTO
    {
        [Required(ErrorMessage = "Id specializarii este obligatoriu.")]
        public int SpecializationId { get; set; }
        [Required(ErrorMessage = "Numele serviciului este obligatoriu.")]
        public string Name { get; set; }
    }
}
