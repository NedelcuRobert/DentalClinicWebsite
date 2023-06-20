using DentalClinicWebsite.Models;

namespace DentalClinicWebsite.Repository.Interfaces
{
    public interface ITreatmentRepository
    {
        IEnumerable<Treatment> GetAllTreatments();
        IEnumerable<Treatment> GetTreatmentsByService(int serviceId);
        Treatment GetTreatmentById(int id);
        Task AddTreatmentAsync(Treatment treatment);
        Task UpdateTreatmentAsync(Treatment treatment);
        Task DeleteTreatmentAsync(int id);
    }
}
