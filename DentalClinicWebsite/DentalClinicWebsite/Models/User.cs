namespace DentalClinicWebsite.Models
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<UserSpecialization> Specializations { get; set; }
    }
}
