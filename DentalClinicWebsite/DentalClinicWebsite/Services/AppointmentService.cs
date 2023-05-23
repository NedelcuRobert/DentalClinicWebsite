using DentalClinicWebsite.Models;
using DentalClinicWebsite.Models.DTOs;
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

        public IEnumerable<Service> GetServices(int specializationId)
        {
            return  _appointmentRepository.GetServices(specializationId);
        }

        public IEnumerable<User> GetDentists(int specializationId)
        {
            return _appointmentRepository.GetDentists(specializationId);
        }

        public async Task<IEnumerable<Appointment>> GetAvailableAppointmentsAsync(int serviceId, string dentistId)
        {
            return await _appointmentRepository.GetAvailableAppointmentsAsync(serviceId, dentistId);
        }

        public async Task CreateAppointmentAsync(AppointmentDTO appointmentDTO)
        {
            var appointment = new Appointment
            {
                UserId = appointmentDTO.UserId,
                DentistId = appointmentDTO.DentistId,
                ServiceId = appointmentDTO.ServiceId,
                CalendarData = appointmentDTO.Date.Date.Add(appointmentDTO.Time)
            };
            await _appointmentRepository.CreateAppointmentAsync(appointment);
        }
        public IEnumerable<Specialization> GetSpecializations()
        {
            return _appointmentRepository.GetSpecializations();
        }
    }
}
