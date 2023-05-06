using DentalClinicWebsite.Models;

namespace DentalClinicWebsite.Repository.Interfaces
{
    public interface ISpecializationRepository
    {
        Task<Specialization> GetByIdAsync(int id);
        Task<IEnumerable<Specialization>> GetAllAsync();
        Task AddAsync(Specialization specialization);
        Task UpdateAsync(Specialization specialization);
        Task RemoveAsync(int id);
    }
}
