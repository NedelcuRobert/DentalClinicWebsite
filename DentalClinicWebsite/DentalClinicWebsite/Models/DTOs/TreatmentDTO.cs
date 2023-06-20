using System.ComponentModel.DataAnnotations;

namespace DentalClinicWebsite.Models.DTOs
{
    public class TreatmentDTO
    {
        [Required(ErrorMessage = "Id serviciului este obligatoriu.")]
        public int ServiceId { get; set; }
        [Required(ErrorMessage = "Numele tratamentului este obligatoriu.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Descrierea tratamentului este obligatorie.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Prețul tratamentului este obligatoriu.")]
        [Range(0, double.MaxValue, ErrorMessage = "Prețul tratamentului trebuie să fie un număr pozitiv.")]
        public decimal Price { get; set; }
    }
}
