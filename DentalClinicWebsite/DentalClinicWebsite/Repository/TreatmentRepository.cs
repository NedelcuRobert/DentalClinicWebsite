using DentalClinicWebsite.Models;
using DentalClinicWebsite.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DentalClinicWebsite.Repository
{
    public class TreatmentRepository : ITreatmentRepository
    {
        private readonly DentalClinicContext _context;
        private readonly DbContextOptions<DentalClinicContext> _contextOptions;


        public TreatmentRepository(DentalClinicContext context, DbContextOptions<DentalClinicContext> contextOptions)
        {
            _context = context;
            _contextOptions = contextOptions;
        }

        public IEnumerable<Treatment> GetAllTreatments()
        {
            using var context = new DentalClinicContext(_contextOptions);
            return context.Treatments.Include(t => t.Service).ToList();
        }

        public IEnumerable<Treatment> GetTreatmentsByService(int serviceId)
        {
            var treatments = _context.Treatments
                .Where(t => t.ServiceId == serviceId)
                .ToList();

            return treatments;
        }

        public Treatment GetTreatmentById(int id)
        {
            return _context.Treatments.Find(id);
        }

        public async Task AddTreatmentAsync(Treatment treatment)
        {
            await _context.Treatments.AddAsync(treatment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTreatmentAsync(Treatment treatment)
        {
            _context.Treatments.Update(treatment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTreatmentAsync(int id)
        {
            var treatment = await _context.Treatments.FindAsync(id);
            if (treatment != null)
            {
                _context.Treatments.Remove(treatment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
