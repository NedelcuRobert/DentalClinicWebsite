using DentalClinicWebsite.Models;

namespace DentalClinicWebsite.Services.Interfaces
{
    public interface IConsultationService
    {
        Consultation GetConsultationById(int id);
        void AddConsultation(Consultation consultation);
        void UpdateConsultation(Consultation consultation);
        void DeleteConsultation(Consultation consultation);
        IEnumerable<Consultation> GetAllConsultations();
    }
}
