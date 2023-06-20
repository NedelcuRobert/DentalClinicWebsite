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

        public IEnumerable<Treatment> GetAllTreatments()
        {
            return _treatmentRepository.GetAllTreatments();
        }

        public IEnumerable<Treatment> GetTreatmentsByService(int serviceId)
        {
            return _treatmentRepository.GetTreatmentsByService(serviceId);    
        }

        public Treatment GetTreatmentById(int id)
        {
            return _treatmentRepository.GetTreatmentById(id);
        }

        public async Task AddTreatmentAsync(Treatment treatment)
        {
            await _treatmentRepository.AddTreatmentAsync(treatment);
        }

        public async Task UpdateTreatmentAsync(Treatment treatment)
        {
            await _treatmentRepository.UpdateTreatmentAsync(treatment);
        }

        public async Task DeleteTreatmentAsync(int id)
        {
            await _treatmentRepository.DeleteTreatmentAsync(id);
        }
    }
}
