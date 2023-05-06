using DentalClinicWebsite.Models;
using DentalClinicWebsite.Repository.Interfaces;
using DentalClinicWebsite.Services.Interfaces;

namespace DentalClinicWebsite.Services
{
    public class SpecializationService : ISpecializationService
    {
        private readonly ISpecializationRepository _repository;

        public SpecializationService(ISpecializationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Specialization> GetByIdAsync(int id)
        {
            var specialization = await _repository.GetByIdAsync(id);

            if (specialization == null)
            {
                throw new ArgumentNullException(nameof(specialization), "Specialization cannot be null");
            }

            return specialization;
        }

        public async Task<IEnumerable<Specialization>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddAsync(Specialization specialization)
        {
            await _repository.AddAsync(specialization);
        }

        public async Task UpdateAsync(Specialization specialization)
        {
            await _repository.UpdateAsync(specialization);
        }

        public async Task RemoveAsync(int id)
        {
            var specialization = await _repository.GetByIdAsync(id);

            if (specialization == null)
            {
                throw new ArgumentNullException(nameof(specialization), "Specialization cannot be null");
            }

            await _repository.RemoveAsync(id);
        }
    }
}
