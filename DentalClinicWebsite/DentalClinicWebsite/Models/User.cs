using Microsoft.AspNetCore.Identity;

namespace DentalClinicWebsite.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Picture { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<UserSpecialization> UserSpecializations { get; set; }
    }
}
