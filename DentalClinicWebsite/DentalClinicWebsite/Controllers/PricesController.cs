using DentalClinicWebsite.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinicWebsite.Controllers
{
    public class PricesController : Controller
    {
        private readonly ITreatmentService _treatmentService;
        public PricesController(ITreatmentService treatmentService)
        {
            _treatmentService = treatmentService;
        }

        [AllowAnonymous]
        public IActionResult Prices()
        {
            var treatments = _treatmentService.GetAllTreatments();

            return View(treatments);
        }
    }
}