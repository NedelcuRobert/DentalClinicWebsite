using DentalClinicWebsite.Models;

namespace DentalClinicWebsite.Repository.Interfaces
{
    public interface IUserSpecializationRepository
    {
        Task<List<UserSpecialization>> GetAllAsync();
        Task<UserSpecialization> GetByIdAsync(int id);
        Task<List<UserSpecialization>> GetByUserIdAsync(int userId);
        Task<List<UserSpecialization>> GetBySpecializationIdAsync(int specializationId);
        Task<UserSpecialization> AddAsync(UserSpecialization userSpecialization);
        Task<UserSpecialization> UpdateAsync(UserSpecialization userSpecialization);
        Task DeleteAsync(UserSpecialization userSpecialization);
    }
}
