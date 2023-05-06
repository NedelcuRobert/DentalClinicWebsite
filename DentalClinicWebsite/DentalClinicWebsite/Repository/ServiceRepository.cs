using DentalClinicWebsite.Models;
using DentalClinicWebsite.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DentalClinicWebsite.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly DentalClinicContext _context;

        public ServiceRepository(DentalClinicContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Service>> GetAllServicesAsync()
        {
            return await _context.Services.Include(s => s.Specialization)
                                            .Include(s => s.Treatments)
                                            .Include(s => s.Appointments)
                                            .ToListAsync();
        }

        public async Task<Service> GetServiceByIdAsync(int id)
        {
            return await _context.Services.Include(s => s.Specialization)
                                            .Include(s => s.Treatments)
                                            .Include(s => s.Appointments)
                                            .FirstOrDefaultAsync(s => s.ID == id);
        }

        public async Task AddServiceAsync(Service service)
        {
            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateServiceAsync(Service service)
        {
            _context.Services.Update(service);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteServiceAsync(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service != null)
            {
                _context.Services.Remove(service);
                await _context.SaveChangesAsync();
            }
        }
    }
}
