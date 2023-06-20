using System.ComponentModel.DataAnnotations;

namespace DentalClinicWebsite.Models.DTOs
{
    public class UserDTO
    {
        [Required(ErrorMessage = "Numele de utilizator este obligatoriu.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Adresa de email este obligatorie.")]
        [EmailAddress(ErrorMessage = "Adresa de email nu este validă.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Parola este obligatorie.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmarea parolei este obligatorie.")]
        [Compare("Password", ErrorMessage = "Parola și confirmarea parolei nu se potrivesc.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
