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
        public ScheduleController()
        {
        }
        [Authorize(Roles = "User")]
        public ActionResult Schedule()
        {

            // Pass the list of appointments to the view
            return View();
        }


    }
}