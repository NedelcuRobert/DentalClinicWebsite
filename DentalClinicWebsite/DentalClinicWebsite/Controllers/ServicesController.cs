using DentalClinicWebsite.Models;
using DentalClinicWebsite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinicWebsite.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ISpecializationService _specializationService;
        private readonly IServiceService _serviceService;
        private readonly ITreatmentService _treatmentService;

        public ServicesController(ISpecializationService specializationService, IServiceService serviceService, ITreatmentService treatmentService)
        {
            _specializationService = specializationService;
            _serviceService = serviceService;
            _treatmentService = treatmentService;
        }

        public IActionResult Services()
        {
            var specializations =  _specializationService.GetAll();

            var servicesForSpecialization = new Dictionary<int, IEnumerable<Service>>();
            var treatmentsForService = new Dictionary<int, IEnumerable<Treatment>>();

            foreach (var specialization in specializations)
            {
                var services = _serviceService.GetServicesBySpecialization(specialization.ID);
                servicesForSpecialization[specialization.ID] = services;
                foreach (var treatment in services)
                {
                    var treatments = _treatmentService.GetTreatmentsByService(treatment.ID);
                    treatmentsForService[treatment.ID] = treatments;
                }
            }

            ViewBag.AllSpecializations = specializations;
            ViewBag.Services = servicesForSpecialization;
            ViewBag.Treatments = treatmentsForService;

            return View(specializations);
        }
    }
}
