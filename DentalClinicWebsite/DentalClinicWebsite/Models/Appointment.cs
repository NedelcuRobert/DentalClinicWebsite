namespace DentalClinicWebsite.Models
{
    public class Appointment
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public int ServiceId { get; set; }
        public DateTime CalendarData { get; set; }

        public virtual User User { get; set; }
        public virtual Service Service { get; set; }
        public virtual Consultation Consultation { get; set; }
    }
}
