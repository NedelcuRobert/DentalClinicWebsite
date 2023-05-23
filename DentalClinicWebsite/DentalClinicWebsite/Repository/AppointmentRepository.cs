using DentalClinicWebsite.Models;
using DentalClinicWebsite.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Diagnostics;

namespace DentalClinicWebsite.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly DentalClinicContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AppointmentRepository(DentalClinicContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IEnumerable<Service> GetServices(int specializationId)
        {
            var services = _context.Set<Service>()
                .Where(s => s.SpecializationId == specializationId);

            return services;
        }

        public IEnumerable<User> GetDentists(int specializationId)
        {
            var userIds = _userManager.GetUsersInRoleAsync("Admin").GetAwaiter().GetResult()
                .Select(u => u.Id).ToList();

            return _context.Set<User>()
                .Where(u => userIds.Contains(u.Id) && u.UserSpecializations.Any(us => us.ID == specializationId))
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
    }

}
