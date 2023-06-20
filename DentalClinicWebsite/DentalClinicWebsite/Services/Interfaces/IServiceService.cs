﻿using DentalClinicWebsite.Models;

namespace DentalClinicWebsite.Services.Interfaces
{
    public interface IServiceService
    {
        IEnumerable<Service> GetAllServices();
        IEnumerable<Service> GetServicesBySpecialization(int specializationId);
        Service GetServiceById(int id);
        Task AddServiceAsync(Service service);
        Task UpdateServiceAsync(Service service);
        Task DeleteServiceAsync(int id);
    }
}
