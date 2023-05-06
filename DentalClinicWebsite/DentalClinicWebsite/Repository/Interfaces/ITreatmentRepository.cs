using DentalClinicWebsite.Models;

namespace DentalClinicWebsite.Repository.Interfaces
{
    public interface ITreatmentRepository
    {
        Task<IEnumerable<Treatment>> GetAllTreatmentsAsync();
        Task<Treatment> GetTreatmentByIdAsync(int id);
        Task<Treatment> CreateTreatmentAsync(Treatment newTreatment);
        Task<Treatment> UpdateTreatmentAsync(Treatment updatedTreatment);
        Task DeleteTreatmentAsync(Treatment treatment);
    }
}
