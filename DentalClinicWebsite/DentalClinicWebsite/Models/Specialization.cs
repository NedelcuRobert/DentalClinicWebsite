
namespace DentalClinicWebsite.Models
{
    public class Specialization
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<UserSpecialization> UserSpecializations { get; set; }
    }
}
