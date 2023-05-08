using DentalClinicWebsite.Models;

namespace DentalClinicWebsite.Services.Interfaces
{
    public interface IUserSpecializationService
    {
        Task<List<UserSpecialization>> GetAllAsync();
        Task<UserSpecialization> GetByIdAsync(int id);
        Task<List<UserSpecialization>> GetByUserIdAsync(string userId);
        Task<List<UserSpecialization>> GetBySpecializationIdAsync(int specializationId);
        Task<UserSpecialization> AddAsync(UserSpecialization userSpecialization);
        Task<UserSpecialization> UpdateAsync(UserSpecialization userSpecialization);
        Task DeleteAsync(int id);
    }
}
