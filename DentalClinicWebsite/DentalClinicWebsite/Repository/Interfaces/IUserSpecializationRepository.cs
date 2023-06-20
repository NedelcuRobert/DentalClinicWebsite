using DentalClinicWebsite.Models;

namespace DentalClinicWebsite.Repository.Interfaces
{
    public interface IUserSpecializationRepository
    {
        Task<UserSpecialization> GetUserSpecializationByIdAsync(int id);
        Task<List<UserSpecialization>> GetUserSpecializationsByUserIdAsync(string userId);
        Task AddUserSpecializationAsync(UserSpecialization userSpecialization);
        Task UpdateUserSpecializationAsync(UserSpecialization userSpecialization);
        Task RemoveUserSpecializationAsync(UserSpecialization userSpecialization);

    }
}
