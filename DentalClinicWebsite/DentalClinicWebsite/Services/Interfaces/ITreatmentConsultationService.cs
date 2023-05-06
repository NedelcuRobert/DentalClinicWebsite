using DentalClinicWebsite.Models;

namespace DentalClinicWebsite.Services.Interfaces
{
    public interface ITreatmentConsultationService
    {
        Task<TreatmentConsultation> GetByIdAsync(int id);
        Task<IEnumerable<TreatmentConsultation>> GetAllAsync();
        Task<IEnumerable<TreatmentConsultation>> GetByConsultationIdAsync(int consultationId);
        Task<IEnumerable<TreatmentConsultation>> GetByTreatmentIdAsync(int treatmentId);
        Task AddAsync(TreatmentConsultation treatmentConsultation);
        Task RemoveAsync(int id);
    }
}
