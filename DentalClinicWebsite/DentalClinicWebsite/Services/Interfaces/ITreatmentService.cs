using DentalClinicWebsite.Models;

namespace DentalClinicWebsite.Services.Interfaces
{
    public interface ITreatmentService
    {
        IEnumerable<Treatment> GetAllTreatments();
        IEnumerable<Treatment> GetTreatmentsByService(int serviceId);
        Treatment GetTreatmentById(int id);
        Task AddTreatmentAsync(Treatment treatment);
        Task UpdateTreatmentAsync(Treatment treatment);
        Task DeleteTreatmentAsync(int id);
    }
}
