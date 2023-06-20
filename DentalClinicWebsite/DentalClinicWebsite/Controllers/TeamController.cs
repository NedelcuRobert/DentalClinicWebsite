using DentalClinicWebsite.Models;
using DentalClinicWebsite.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinicWebsite.Controllers
{
    public class TeamController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ISpecializationService _specializationService;
        public TeamController(UserManager<User> userManager,ISpecializationService specializationService)
        {
            _userManager = userManager;
            _specializationService = specializationService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Team()
        {
            var dentists = await _userManager.GetUsersInRoleAsync("Dentist");

            var specializationsDict = new Dictionary<string, IEnumerable<string>>();

            foreach (var dentist in dentists)
            {
                var specializations = await _specializationService.GetSpecializationsForDentist(dentist.Id);
                specializationsDict[dentist.Id] = specializations;
            }

            ViewBag.Specializations = specializationsDict;
            ViewBag.Dentists = dentists;

            return View(dentists);
        }
    }
}
