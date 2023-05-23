﻿namespace DentalClinicWebsite.Models
{
    public class Appointment
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public string DentistId { get; set; }
        public int ServiceId { get; set; }
        public DateTime CalendarData { get; set; }
        public virtual User User { get; set; }
        public virtual User Dentist { get; set; }
        public virtual Service Service { get; set; }
        public virtual Consultation Consultation { get; set; }
    }
}
