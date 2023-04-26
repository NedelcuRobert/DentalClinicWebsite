namespace DentalClinicWebsite.Models
{
    public class Review
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        public virtual User User { get; set; }
    }
}
