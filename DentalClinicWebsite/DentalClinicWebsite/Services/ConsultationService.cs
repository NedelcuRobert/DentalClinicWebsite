using DentalClinicWebsite.Models;
using DentalClinicWebsite.Repository.Interfaces;
using DentalClinicWebsite.Services.Interfaces;

namespace DentalClinicWebsite.Services
{
    public class ConsultationService : IConsultationService
    {
        private readonly IConsultationRepository _consultationRepository;

        public ConsultationService(IConsultationRepository consultationRepository)
        {
            _consultationRepository = consultationRepository;
        }

        public Consultation GetConsultationById(int id)
        {
            return _consultationRepository.GetConsultationById(id);
        }

        public void AddConsultation(Consultation consultation)
        {
            if (consultation == null)
            {
                throw new ArgumentNullException(nameof(consultation), "Consultation cannot be null");
            }

            _consultationRepository.AddConsultation(consultation);
        }

        public void UpdateConsultation(Consultation consultation)
        {
            if (consultation == null)
            {
                throw new ArgumentNullException(nameof(consultation), "Consultation cannot be null");
            }

            _consultationRepository.UpdateConsultation(consultation);
        }

        public void DeleteConsultation(Consultation consultation)
        {
            if (consultation == null)
            {
                throw new ArgumentNullException(nameof(consultation), "Consultation cannot be null");
            }

            _consultationRepository.DeleteConsultation(consultation);
        }

        public IEnumerable<Consultation> GetAllConsultations()
        {
            return _consultationRepository.GetAllConsultations();
        }
    }
}
