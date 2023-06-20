using Microsoft.AspNetCore.Identity;

namespace DentalClinicWebsite.Models.DTOs
{
    public class AdminDTO
    {
        public Task<IEnumerable<User>> Users { get; set; }
        public IEnumerable<Service> Services { get; set; }
        public IEnumerable<Treatment> Treatments { get; set; }
        public List<Specialization> UserSpecializations { get; set; }
    }
}
