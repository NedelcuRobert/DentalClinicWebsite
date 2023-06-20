using DentalClinicWebsite.Models;
using DentalClinicWebsite.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DentalClinicWebsite.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly DentalClinicContext _context;
        private readonly DbContextOptions<DentalClinicContext> _contextOptions;


        public ServiceRepository(DentalClinicContext context, DbContextOptions<DentalClinicContext> contextOptions)
        {
            _context = context;
            _contextOptions = contextOptions;
        }

        public IEnumerable<Service> GetAllServices()
        {
            using var context = new DentalClinicContext(_contextOptions);
            return context.Services.Include(s => s.Specialization).ToList();
        }

        public IEnumerable<Service> GetServicesBySpecialization(int specializationId)
        {
            var services = _context.Services
                .Include(s => s.Treatments)
                .Where(s => s.SpecializationId == specializationId)
                .ToList();

            return services;
        }

        public Service GetServiceById(int id)
        {
            return _context.Services.Find(id);
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
