using DentalClinicWebsite.Models;

namespace DentalClinicWebsite.Services.Interfaces
{
    public interface ISpecializationService
    {
        Task<IEnumerable<string>> GetSpecializationsForDentist(string dentistId);
        Task<Specialization> GetByIdAsync(int id);
        IEnumerable<Specialization> GetAll();
        Task AddAsync(Specialization specialization);
        Task UpdateAsync(Specialization specialization);
        Task RemoveAsync(int id);
    }
}
