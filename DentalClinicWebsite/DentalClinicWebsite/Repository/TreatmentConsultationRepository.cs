using DentalClinicWebsite.Models;
using DentalClinicWebsite.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DentalClinicWebsite.Repository
{
    public class TreatmentConsultationRepository : ITreatmentConsultationRepository
    {
        private readonly DentalClinicContext _context;

        public TreatmentConsultationRepository(DentalClinicContext context)
        {
            _context = context;
        }

        public async Task<TreatmentConsultation> GetByIdAsync(int id)
        {
            return await _context.TreatmentConsultations.FindAsync(id);
        }

        public async Task<IEnumerable<TreatmentConsultation>> GetAllAsync()
        {
            return await _context.TreatmentConsultations.ToListAsync();
        }

        public async Task<IEnumerable<TreatmentConsultation>> GetByConsultationIdAsync(int consultationId)
        {
            return await _context.TreatmentConsultations
                .Where(tc => tc.ConsultationId == consultationId)
                .ToListAsync();
        }

        public async Task<IEnumerable<TreatmentConsultation>> GetByTreatmentIdAsync(int treatmentId)
        {
            return await _context.TreatmentConsultations
                .Where(tc => tc.TreatmentId == treatmentId)
                .ToListAsync();
        }

        public async Task AddAsync(TreatmentConsultation treatmentConsultation)
        {
            await _context.TreatmentConsultations.AddAsync(treatmentConsultation);
            await _context.SaveChangesAsync();
        }

        public void Remove(TreatmentConsultation treatmentConsultation)
        {
            _context.TreatmentConsultations.Remove(treatmentConsultation);
            _context.SaveChanges();
        }

        public Task UpdateAsync(TreatmentConsultation existingTreatmentConsultation)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(TreatmentConsultation treatmentConsultation)
        {
            throw new NotImplementedException();
        }
    }
}
