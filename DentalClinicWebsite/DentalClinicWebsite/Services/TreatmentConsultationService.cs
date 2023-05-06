using DentalClinicWebsite.Models;
using DentalClinicWebsite.Repository.Interfaces;
using DentalClinicWebsite.Services.Interfaces;


namespace DentalClinicWebsite.Services
{
    public class TreatmentConsultationService : ITreatmentConsultationService
    {
        private readonly ITreatmentConsultationRepository _repository;

        public TreatmentConsultationService(ITreatmentConsultationRepository repository)
        {
            _repository = repository;
        }

        public async Task<TreatmentConsultation> GetByIdAsync(int id)
        {
            var treatmentConsultation = await _repository.GetByIdAsync(id);

            if (treatmentConsultation == null)
            {
                throw new ArgumentNullException(nameof(treatmentConsultation), "TreatmentConsultation cannot be null");
            }

            return treatmentConsultation;
        }

        public async Task<IEnumerable<TreatmentConsultation>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<TreatmentConsultation>> GetByConsultationIdAsync(int consultationId)
        {
            return await _repository.GetByConsultationIdAsync(consultationId);
        }

        public async Task<IEnumerable<TreatmentConsultation>> GetByTreatmentIdAsync(int treatmentId)
        {
            return await _repository.GetByTreatmentIdAsync(treatmentId);
        }

        public async Task AddAsync(TreatmentConsultation treatmentConsultation)
        {
            await _repository.AddAsync(treatmentConsultation);
        }

        public async Task RemoveAsync(int id)
        {
            var treatmentConsultation = await _repository.GetByIdAsync(id);

            if (treatmentConsultation == null)
            {
                throw new ArgumentNullException(nameof(treatmentConsultation), "TreatmentConsultation cannot be null");
            }

            await _repository.RemoveAsync(treatmentConsultation);
        }

        public async Task UpdateAsync(TreatmentConsultation treatmentConsultation)
        {
            var existingTreatmentConsultation = await _repository.GetByIdAsync(treatmentConsultation.ID);

            if (existingTreatmentConsultation == null)
            {
                throw new ArgumentNullException(nameof(treatmentConsultation), "TreatmentConsultation cannot be null");
            }

            existingTreatmentConsultation.ConsultationId = treatmentConsultation.ConsultationId;
            existingTreatmentConsultation.TreatmentId = treatmentConsultation.TreatmentId;

            await _repository.UpdateAsync(existingTreatmentConsultation);
        }
    }
}
