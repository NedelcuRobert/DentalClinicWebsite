using DentalClinicWebsite.Models;
using DentalClinicWebsite.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DentalClinicWebsite.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly DentalClinicContext _context;

        public AppointmentRepository(DentalClinicContext context)
        {
            _context = context;
        }

        public IEnumerable<Appointment> GetAllAppointments()
        {
            return _context.Appointments
                            .Include(a => a.User)
                            .Include(a => a.Consultation)
                            .ToList();
        }

        public Appointment GetAppointmentById(int id)
        {
            return _context.Appointments
                            .Include(a => a.User)
                            .Include(a => a.Consultation)
                            .FirstOrDefault(a => a.ID == id);
        }

        public void AddAppointment(Appointment appointment)
        {
            if (appointment == null)
            {
                throw new ArgumentNullException(nameof(appointment), "Appointment cannot be null");
            }

            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }

        public void UpdateAppointment(Appointment appointment)
        {
            if (appointment == null)
            {
                throw new ArgumentNullException(nameof(appointment), "Appointment cannot be null");
            }

            _context.Entry(appointment).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteAppointment(int id)
        {
            var appointment = _context.Appointments.FirstOrDefault(a => a.ID == id);

            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                _context.SaveChanges();
            }
        }
    }

}
