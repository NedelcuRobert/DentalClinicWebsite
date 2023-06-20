using DentalClinicWebsite.Models;

namespace DentalClinicWebsite.Repository.Interfaces
{
    public interface ISpecializationRepository
    {
        Task<IEnumerable<string>> GetSpecializationsForDentist(string dentistId);
        Task<Specialization> GetByIdAsync(int id);
        IEnumerable<Specialization> GetAllSpecializations();
        Task AddAsync(Specialization specialization);
        Task UpdateAsync(Specialization specialization);
        Task RemoveAsync(int id);
    }
}
