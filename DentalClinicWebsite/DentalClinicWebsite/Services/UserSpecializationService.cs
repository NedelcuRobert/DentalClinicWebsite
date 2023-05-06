using DentalClinicWebsite.Models;
using DentalClinicWebsite.Repository.Interfaces;
using DentalClinicWebsite.Services.Interfaces;

namespace DentalClinicWebsite.Services
{
    public class UserSpecializationService : IUserSpecializationService
    {
        private readonly IUserSpecializationRepository _userSpecializationRepository;

        public UserSpecializationService(IUserSpecializationRepository userSpecializationRepository)
        {
            _userSpecializationRepository = userSpecializationRepository;
        }

        public async Task<List<UserSpecialization>> GetAllAsync()
        {
            return await _userSpecializationRepository.GetAllAsync();
        }

        public async Task<UserSpecialization> GetByIdAsync(int id)
        {
            return await _userSpecializationRepository.GetByIdAsync(id);
        }

        public async Task<List<UserSpecialization>> GetByUserIdAsync(int userId)
        {
            return await _userSpecializationRepository.GetByUserIdAsync(userId);
        }

        public async Task<List<UserSpecialization>> GetBySpecializationIdAsync(int specializationId)
        {
            return await _userSpecializationRepository.GetBySpecializationIdAsync(specializationId);
        }

        public Task<UserSpecialization> AddAsync(UserSpecialization userSpecialization)
        {
            throw new NotImplementedException();
        }

        public Task<UserSpecialization> UpdateAsync(UserSpecialization userSpecialization)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
