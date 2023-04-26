namespace DentalClinicWebsite.Models
{
    public class Billing
    {
        public int ID { get; set; }
        public int ConsultationId { get; set; }
        public decimal Price { get; set; }
        public DateTime CalendarData { get; set; }
        public string Details { get; set; }

        public virtual Consultation Consultation { get; set; }
    }
}
