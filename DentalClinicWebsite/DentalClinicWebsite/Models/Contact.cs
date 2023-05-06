using System.ComponentModel.DataAnnotations;

namespace DentalClinicWebsite.Models
{
    public class Contact
    {
        [Required(ErrorMessage = "Vă rugăm să introduceți numele dumneavoastră")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vă rugăm să introduceți adresa dumneavoastră de email")]
        [EmailAddress(ErrorMessage = "Vă rugăm să introduceți o adresă de email validă")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vă rugăm să introduceți subiectul mesajului")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Vă rugăm să introduceți un mesaj")]
        public string Message { get; set; }
    }
}
