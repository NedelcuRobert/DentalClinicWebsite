namespace DentalClinicWebsite.Models
{
    public class Service
    {
        public int ID { get; set; }
        public int SpecializationId { get; set; }
        public string Name { get; set; }
        public virtual Specialization Specialization { get; set; }
        public virtual ICollection<Treatment> Treatments { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
