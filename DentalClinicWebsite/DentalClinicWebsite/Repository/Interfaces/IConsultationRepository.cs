using DentalClinicWebsite.Models;

namespace DentalClinicWebsite.Repository.Interfaces
{
    public interface IConsultationRepository
    {
        Consultation GetConsultationById(int id);
        void AddConsultation(Consultation consultation);
        void UpdateConsultation(Consultation consultation);
        void DeleteConsultation(Consultation consultation);
        IEnumerable<Consultation> GetAllConsultations();
    }
}
