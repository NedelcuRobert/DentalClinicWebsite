using DentalClinicWebsite.Models;
using DentalClinicWebsite.Repository.Interfaces;
using DentalClinicWebsite.Services.Interfaces;

namespace DentalClinicWebsite.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<IEnumerable<Service>> GetAllServicesAsync()
        {
            return await _serviceRepository.GetAllServicesAsync();
        }

        public async Task<Service> GetServiceByIdAsync(int id)
        {
            return await _serviceRepository.GetServiceByIdAsync(id);
        }

        public async Task AddServiceAsync(Service service)
        {
            await _serviceRepository.AddServiceAsync(service);
        }

        public async Task UpdateServiceAsync(Service service)
        {
            await _serviceRepository.UpdateServiceAsync(service);
        }

        public async Task DeleteServiceAsync(int id)
        {
            await _serviceRepository.DeleteServiceAsync(id);
        }
    }
}
