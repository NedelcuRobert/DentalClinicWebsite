using DentalClinicWebsite.Models.DTOs;
using DentalClinicWebsite.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace DentalClinicWebsite.Controllers
{
    [Authorize]
    public class ScheduleController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        public ScheduleController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public IActionResult Schedule()
        {
            var specializations = _appointmentService.GetSpecializations();
            ViewBag.Specializations = specializations;
            return View();
        }

        [HttpGet]
        public IActionResult GetServices(int specializationId)
        {
            var services = _appointmentService.GetServices(specializationId);
            return Json(services);
        }

        [HttpGet]
        public IActionResult GetDentists(int specializationId)
        {
            var dentists = _appointmentService.GetDentists(specializationId);
            return Json(dentists);
        }

        [HttpGet]
        public async Task<IActionResult> GetAvailableAppointments(int serviceId, string dentistId)
        {
            var appointments = await _appointmentService.GetAvailableAppointmentsAsync(serviceId, dentistId);
            return Json(appointments);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment(AppointmentDTO appointmentDTO)
        {

            if (ModelState.IsValid)
            {
                TempData["SuccessMessage"] = "Programarea a fost realizată cu succes.";
                await _appointmentService.CreateAppointmentAsync(appointmentDTO);
                return RedirectToAction("Schedule", "Schedule");
            }
            else
            {
                var specializations = _appointmentService.GetSpecializations();
                ViewBag.Specializations = specializations;
                return View("", appointmentDTO);
            }
        }
    }
}