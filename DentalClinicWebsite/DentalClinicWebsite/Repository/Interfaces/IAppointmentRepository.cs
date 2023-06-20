using DentalClinicWebsite.Models;

namespace DentalClinicWebsite.Repository.Interfaces
{
    public interface IAppointmentRepository
    {
        IEnumerable<User> GetDentists(int specializationId);
        IEnumerable<Service> GetServices(int specializationId);
        Task<IEnumerable<Appointment>> GetAvailableAppointmentsAsync(int serviceId, string dentistId);
        Task CreateAppointmentAsync(Appointment appointment);
        IEnumerable<Specialization> GetSpecializations();
        IEnumerable<Appointment> GetAppointmentsById(string Id);
    }
}
