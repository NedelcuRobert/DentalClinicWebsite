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
        private readonly IServiceService _serviceService;
        private readonly IAppointmentService _appointmentService;


    }
}