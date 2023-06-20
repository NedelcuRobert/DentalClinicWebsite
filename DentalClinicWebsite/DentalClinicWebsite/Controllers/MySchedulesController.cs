using DentalClinicWebsite.Models;
using DentalClinicWebsite.Repository.Interfaces;
using DentalClinicWebsite.Services;
using DentalClinicWebsite.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Data;
using System.Security.Claims;

public class MySchedulesController : Controller
{
    private readonly IAppointmentService _appointmentService;

    public MySchedulesController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }
    [Authorize(Roles = "Dentist,User")]
    public IActionResult MySchedules()
    {
        string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var appointments = _appointmentService.GetAppointmentsById(userId);


        Console.WriteLine("Valoarea listei de programări:");
        foreach (var appointment in appointments)
        {
            Console.WriteLine(appointment);
        }

        return View("MySchedules", appointments);
    }
}
