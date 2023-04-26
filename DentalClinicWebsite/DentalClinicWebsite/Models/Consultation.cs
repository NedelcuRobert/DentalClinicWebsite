namespace DentalClinicWebsite.Models
{
    public class Consultation
    {
        public int ID { get; set; }
        public int AppointmentId { get; set; }
        public int TreatmentId { get; set; }
        public string Description { get; set; }

        public virtual Appointment Appointment { get; set; }
        public virtual Treatment Treatment { get; set; }
        public virtual Billing Billing { get; set; }
        public virtual ICollection<TreatmentConsultation> TreatmentConsultations { get; set; }
    }
}
