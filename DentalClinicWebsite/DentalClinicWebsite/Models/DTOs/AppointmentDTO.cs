namespace DentalClinicWebsite.Models.DTOs
{
    public class AppointmentDTO
    {
        public string UserId { get; set; }
        public string DentistId { get; set; }
        public int ServiceId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
    }
}
