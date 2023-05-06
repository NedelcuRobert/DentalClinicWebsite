using DentalClinicWebsite.Models;
using DentalClinicWebsite.Repository;
using DentalClinicWebsite.Repository.Interfaces;
using DentalClinicWebsite.Services;
using DentalClinicWebsite.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinicWebsite.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IServiceService _serviceService;
        private readonly IAppointmentService _appointmentService;

        public ScheduleController(IUserRepository userRepository, IServiceService serviceService, IAppointmentService appointmentService)
        {
            _userRepository = userRepository;
            _serviceService = serviceService;
            _appointmentService = appointmentService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Schedule()
        {
            var admins = _userRepository.GetAllAdmins();
            var services = await _serviceService.GetAllServicesAsync();

            // returnează o View care afișează medicii și serviciile
            return View(new DentistServices { Services = (List<Service>)services , Dentists = admins});
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Schedule(Service service, User user, string data, string ora)
        {

            // Transformăm data și ora într-un obiect DateTime
            var dataOra = DateTime.Parse($"{data} {ora}");

            // Salvăm programarea în baza de date
            var programare = new Appointment
            {
                ServiceId = service.ID,
                UserId = user.ID,
                CalendarData = dataOra
            };

            _appointmentService.CreateAppointment(programare);

            return RedirectToAction("", "Home");
        }

    }
}