using DentalClinicWebsite.Models;
using DentalClinicWebsite.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DentalClinicWebsite.Repository
{
    public class ConsultationRepository : IConsultationRepository
    {
        private readonly DentalClinicContext _context;

        public ConsultationRepository(DentalClinicContext context)
        {
            _context = context;
        }

        public Consultation GetConsultationById(int id)
        {
            return _context.Set<Consultation>().SingleOrDefault(c => c.ID == id);
        }

        public void AddConsultation(Consultation consultation)
        {
            if (consultation == null)
            {
                throw new ArgumentNullException(nameof(consultation), "Consultation cannot be null");
            }

            _context.Set<Consultation>().Add(consultation);
            _context.SaveChanges();
        }

        public void UpdateConsultation(Consultation consultation)
        {
            if (consultation == null)
            {
                throw new ArgumentNullException(nameof(consultation), "Consultation cannot be null");
            }

            _context.Entry(consultation).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteConsultation(Consultation consultation)
        {
            if (consultation == null)
            {
                throw new ArgumentNullException(nameof(consultation), "Consultation cannot be null");
            }

            _context.Set<Consultation>().Remove(consultation);
            _context.SaveChanges();
        }

        public IEnumerable<Consultation> GetAllConsultations()
        {
            return _context.Set<Consultation>().ToList();
        }
    }
}
