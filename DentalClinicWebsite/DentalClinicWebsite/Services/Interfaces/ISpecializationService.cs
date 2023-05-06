using DentalClinicWebsite.Models;

namespace DentalClinicWebsite.Services.Interfaces
{
    public interface ISpecializationService
    {
        Task<Specialization> GetByIdAsync(int id);
        Task<IEnumerable<Specialization>> GetAllAsync();
        Task AddAsync(Specialization specialization);
        Task UpdateAsync(Specialization specialization);
        Task RemoveAsync(int id);
    }
}
