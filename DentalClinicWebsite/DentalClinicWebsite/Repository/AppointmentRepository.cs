using DentalClinicWebsite.Models;
using DentalClinicWebsite.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DentalClinicWebsite.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly DentalClinicContext _context;
        private readonly UserManager<User> _userManager;

        public AppointmentRepository(DentalClinicContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IEnumerable<Service> GetServices(int specializationId)
        {
            var services = _context.Set<Service>()
                .Where(s => s.SpecializationId == specializationId);

            return services;
        }

        public IEnumerable<User> GetDentists(int specializationId)
        {

            return _context.Users.Where(u => u.UserSpecializations.Any(us => us.SpecializationId == specializationId))
                    .ToList();
        }

        public async Task<IEnumerable<Appointment>> GetAvailableAppointmentsAsync(int serviceId, string dentistId)
        {
            return await _context.Set<Appointment>()
                .Where(a => a.ID == serviceId && a.UserId == dentistId)
                .ToListAsync();
        }

        public async Task CreateAppointmentAsync(Appointment appointment)
        {
            _context.Set<Appointment>().Add(appointment);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Specialization> GetSpecializations()
        {
            return _context.Set<Specialization>();
        }

        public IEnumerable<Appointment> GetAppointmentsById(string id)
        {
            var user = _userManager.FindByIdAsync(id).Result;
            var roles = _userManager.GetRolesAsync(user).Result;

            if (roles.Contains("Dentist"))
            {
                return _context.Appointments
                    .Include(a => a.User)
                    .Include(a => a.Dentist)
                    .Include(a => a.Service)
                    .Where(a => a.DentistId == id)
                    .ToList();
            }
            else
            {
                return _context.Appointments
                    .Include(a => a.User)
                    .Include(a => a.Dentist)
                    .Include(a => a.Service)
                    .Where(a => a.UserId == id)
                    .ToList();
            }
        }
    }
}
