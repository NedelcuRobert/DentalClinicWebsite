using DentalClinicWebsite.Models;
using DentalClinicWebsite.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DentalClinicWebsite.Repository
{
    public class TreatmentRepository : ITreatmentRepository
    {
        private readonly DentalClinicContext _context;

        public TreatmentRepository(DentalClinicContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Treatment>> GetAllTreatmentsAsync()
        {
            return await _context.Treatments.ToListAsync();
        }

        public async Task<Treatment> GetTreatmentByIdAsync(int id)
        {
            return await _context.Treatments.FindAsync(id);
        }

        public async Task<Treatment> CreateTreatmentAsync(Treatment newTreatment)
        {
            _context.Treatments.Add(newTreatment);
            await _context.SaveChangesAsync();
            return newTreatment;
        }

        public async Task<Treatment> UpdateTreatmentAsync(Treatment updatedTreatment)
        {
            _context.Entry(updatedTreatment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return updatedTreatment;
        }

        public async Task DeleteTreatmentAsync(Treatment treatment)
        {
            _context.Treatments.Remove(treatment);
            await _context.SaveChangesAsync();
        }
    }
}
