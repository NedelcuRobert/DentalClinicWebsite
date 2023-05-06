using DentalClinicWebsite.Models;

namespace DentalClinicWebsite.Repository.Interfaces
{
    public interface ITreatmentConsultationRepository
    {
        Task<TreatmentConsultation> GetByIdAsync(int id);
        Task<IEnumerable<TreatmentConsultation>> GetAllAsync();
        Task<IEnumerable<TreatmentConsultation>> GetByConsultationIdAsync(int consultationId);
        Task<IEnumerable<TreatmentConsultation>> GetByTreatmentIdAsync(int treatmentId);
        Task AddAsync(TreatmentConsultation treatmentConsultation);
        void Remove(TreatmentConsultation treatmentConsultation);
        Task UpdateAsync(TreatmentConsultation existingTreatmentConsultation);
        Task RemoveAsync(TreatmentConsultation treatmentConsultation);
    }

}
