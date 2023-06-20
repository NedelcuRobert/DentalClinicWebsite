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

        public IEnumerable<Service> GetAllServices()
        {
            return _serviceRepository.GetAllServices();
        }

        public IEnumerable<Service> GetServicesBySpecialization(int specializationId)
        {
            return _serviceRepository.GetServicesBySpecialization(specializationId);
        }

        public Service GetServiceById(int id)
        {
            return  _serviceRepository.GetServiceById(id);
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
