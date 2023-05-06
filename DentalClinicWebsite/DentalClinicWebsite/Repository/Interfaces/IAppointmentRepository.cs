using DentalClinicWebsite.Models;

namespace DentalClinicWebsite.Repository.Interfaces
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> GetAllAppointments();
        Appointment GetAppointmentById(int id);
        void AddAppointment(Appointment appointment);
        void UpdateAppointment(Appointment appointment);
        void DeleteAppointment(int id);
    }
}
