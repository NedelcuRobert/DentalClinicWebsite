using DentalClinicWebsite.Models;

namespace DentalClinicWebsite.Services.Interfaces
{
    public interface ITreatmentService
    {
        Task<IEnumerable<Treatment>> GetAllTreatmentsAsync();
        Task<Treatment> GetTreatmentByIdAsync(int id);
        Task<Treatment> CreateTreatmentAsync(Treatment newTreatment);
        Task<Treatment> UpdateTreatmentAsync(Treatment updatedTreatment);
        Task DeleteTreatmentAsync(Treatment treatment);
    }
}
