using DentalClinicWebsite.Models;

namespace DentalClinicWebsite.Services.Interfaces
{
    public interface IAppointmentService
    {
        IEnumerable<Appointment> GetAllAppointments();
        Appointment GetAppointmentById(int id);
        void CreateAppointment(Appointment appointment);
        void UpdateAppointment(Appointment appointment);
        void DeleteAppointment(int id);
    }
}
