using DentalClinicWebsite.Models;
using DentalClinicWebsite.Models.DTOs;
using DentalClinicWebsite.Repository;
using DentalClinicWebsite.Repository.Interfaces;
using DentalClinicWebsite.Services;
using DentalClinicWebsite.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DentalClinicWebsite.Controllers
{
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
            // Obțineți lista de servicii disponibile pentru specializarea selectată și transmiteți-o ca răspuns JSON
            var services = _appointmentService.GetServices(specializationId);
            return Json(services);
        }

        [HttpGet]
        public IActionResult GetDentists(int specializationId)
        {
            // Obțineți lista de dentisti disponibili pentru serviciul selectat și transmiteți-o ca răspuns JSON
            var dentists = _appointmentService.GetDentists(specializationId);
            return Json(dentists);
        }

        [HttpGet]
        public async Task<IActionResult> GetAvailableAppointments(int serviceId, string dentistId)
        {
            // Obțineți lista de programări disponibile pentru serviciul și dentistul selectat și transmiteți-o ca răspuns JSON
            var appointments = await _appointmentService.GetAvailableAppointmentsAsync(serviceId, dentistId);
            return Json(appointments);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment(AppointmentDTO appointmentDTO)
        {
            // Validați și creați programarea
            if (ModelState.IsValid)
            {
                await _appointmentService.CreateAppointmentAsync(appointmentDTO);
                return RedirectToAction("Schedule", "Schedule");
            }
            else
            {
                // Tratați cazul în care datele introduse sunt invalide și reveniți la view-ul de programare cu erori de validare
                var specializations = _appointmentService.GetSpecializations();
                ViewBag.Specializations = specializations;
                return View("", appointmentDTO);
            }
        }
    }
}