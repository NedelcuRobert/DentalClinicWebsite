namespace DentalClinicWebsite.Models
{
    public class Treatment
    {
        public int ID { get; set; }
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public virtual Service Service { get; set; }
        public virtual ICollection<TreatmentConsultation> TreatmentConsultations { get; set; }
    }

}
