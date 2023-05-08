namespace DentalClinicWebsite.Models
{
    public class UserSpecialization
    {
        public int ID { get; set; }
        public int SpecializationId { get; set; }
        public string UserId { get; set; }

        public virtual Specialization Specialization { get; set; }
        public virtual User User { get; set; }
    }
}
