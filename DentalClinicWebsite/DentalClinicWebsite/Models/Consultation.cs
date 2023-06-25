namespace DentalClinicWebsite.Models
{
    public class Consultation
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public virtual Billing Billing { get; set; }
        public virtual ICollection<TreatmentConsultation> TreatmentConsultations { get; set; }
    }
}
