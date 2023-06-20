namespace DentalClinicWebsite.Models
{
    public class TreatmentConsultation
    {
        public int ID { get; set; }
        public int ConsultationId { get; set; }
        public int TreatmentId { get; set; }
        public virtual Consultation Consultation { get; set; }
        public virtual Treatment Treatment { get; set; }
    }
}
