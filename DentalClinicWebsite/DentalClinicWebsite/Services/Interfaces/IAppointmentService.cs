using DentalClinicWebsite.Models;
using DentalClinicWebsite.Models.DTOs;
using System.Threading.Tasks;

namespace DentalClinicWebsite.Services.Interfaces
{
    public interface IAppointmentService
    {
        IEnumerable<Service> GetServices(int specializationId);
        IEnumerable<User> GetDentists(int specializationId);
        Task<IEnumerable<Appointment>> GetAvailableAppointmentsAsync(int serviceId, string dentistId);
        Task CreateAppointmentAsync(AppointmentDTO appointmentDTO);
        IEnumerable<Specialization> GetSpecializations();
    }
}
