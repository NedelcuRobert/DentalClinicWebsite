using DentalClinicWebsite.Models;
using DentalClinicWebsite.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DentalClinicWebsite.Repository
{
    public class SpecializationRepository : ISpecializationRepository
    {
        private readonly DentalClinicContext _context;

        public SpecializationRepository(DentalClinicContext context)
        {
            _context = context;
        }

        public async Task<Specialization> GetByIdAsync(int id)
        {
            return await _context.Specializations.FindAsync(id);
        }

        public async Task<IEnumerable<Specialization>> GetAllAsync()
        {
            return await _context.Specializations.ToListAsync();
        }

        public async Task AddAsync(Specialization specialization)
        {
            await _context.Specializations.AddAsync(specialization);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Specialization specialization)
        {
            _context.Entry(specialization).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var specialization = await GetByIdAsync(id);
            if (specialization != null)
            {
                _context.Specializations.Remove(specialization);
                await _context.SaveChangesAsync();
            }
        }
    }
}
