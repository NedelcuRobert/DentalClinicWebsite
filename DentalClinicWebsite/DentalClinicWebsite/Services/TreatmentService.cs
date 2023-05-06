using DentalClinicWebsite.Models;
using DentalClinicWebsite.Repository.Interfaces;
using DentalClinicWebsite.Services.Interfaces;

namespace DentalClinicWebsite.Services
{
    public class TreatmentService : ITreatmentService
    {
        private readonly ITreatmentRepository _treatmentRepository;

        public TreatmentService(ITreatmentRepository treatmentRepository)
        {
            _treatmentRepository = treatmentRepository;
        }

        public async Task<IEnumerable<Treatment>> GetAllTreatmentsAsync()
        {
            return await _treatmentRepository.GetAllTreatmentsAsync();
        }

        public async Task<Treatment> GetTreatmentByIdAsync(int id)
        {
            return await _treatmentRepository.GetTreatmentByIdAsync(id);
        }

        public async Task<Treatment> CreateTreatmentAsync(Treatment newTreatment)
        {
            return await _treatmentRepository.CreateTreatmentAsync(newTreatment);
        }

        public async Task<Treatment> UpdateTreatmentAsync(Treatment updatedTreatment)
        {
            return await _treatmentRepository.UpdateTreatmentAsync(updatedTreatment);
        }

        public async Task DeleteTreatmentAsync(Treatment treatment)
        {
            await _treatmentRepository.DeleteTreatmentAsync(treatment);
        }
    }
}
