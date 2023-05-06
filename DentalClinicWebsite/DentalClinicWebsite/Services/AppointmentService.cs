using DentalClinicWebsite.Models;
using DentalClinicWebsite.Repository.Interfaces;
using DentalClinicWebsite.Services.Interfaces;

namespace DentalClinicWebsite.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public IEnumerable<Appointment> GetAllAppointments()
        {
            return _appointmentRepository.GetAllAppointments();
        }

        public Appointment GetAppointmentById(int id)
        {
            return _appointmentRepository.GetAppointmentById(id);
        }

        public void CreateAppointment(Appointment appointment)
        {
            if (appointment == null)
            {
                throw new ArgumentNullException(nameof(appointment), "Appointment cannot be null");
            }

            _appointmentRepository.AddAppointment(appointment);
        }

        public void UpdateAppointment(Appointment appointment)
        {
            if (appointment == null)
            {
                throw new ArgumentNullException(nameof(appointment), "Appointment cannot be null");
            }

            _appointmentRepository.UpdateAppointment(appointment);
        }

        public void DeleteAppointment(int id)
        {
            _appointmentRepository.DeleteAppointment(id);
        }
    }
}
