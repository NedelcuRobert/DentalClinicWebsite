using DentalClinicWebsite.Models;
using DentalClinicWebsite.Models.DTOs;
using DentalClinicWebsite.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinicWebsite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IServiceService _serviceService;
        private readonly ITreatmentService _treatmentService;

        public readonly AdminDTO _adminDTO;


        public AdminController(IUserService userService, IServiceService serviceService, ITreatmentService treatmentService)
        {
            _userService = userService;
            _serviceService = serviceService;
            _treatmentService = treatmentService;
            _adminDTO = new AdminDTO()
            {
                Users = _userService.GetAllUsersAsync(),
                Services = _serviceService.GetAllServices(),
                Treatments = _treatmentService.GetAllTreatments()
            };
        }

        [HttpGet]
        public IActionResult Admin()
        {

            return View(_adminDTO);
        }

        [HttpGet]
        public IActionResult EditUser(string id)
        {
                var user =  _userService.GetUserByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }

                return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(User user, string role, int specializationId)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.UpdateUserAsync(user, role, specializationId);
                if (result)
                {
                    return RedirectToAction("Admin");
                }
            }

            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("DeleteUser")]
        public async Task<IActionResult> ConfirmDeleteUser(string id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (result)
            {
                return RedirectToAction("Admin");
            }

            TempData["ErrorMessage"] = "Nu s-a putut șterge utilizatorul.";
            return RedirectToAction("Admin");
        }

        [HttpGet]
        public IActionResult AddService()
        {
            var model = new ServiceDTO();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddService(ServiceDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new Service
            {
                Name = model.Name,
            };

            await _serviceService.AddServiceAsync(service);

            return RedirectToAction("Admin");
        }

        [HttpGet]
        public IActionResult EditService(int id)
        {
            var service =  _serviceService.GetServiceById(id);

            if (service == null)
            {
                return NotFound();
            }

            var model = new ServiceDTO
            {
                Name = service.Name
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditService(ServiceDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = _serviceService.GetServiceById(model.SpecializationId);

            if (service == null)
            {
                return NotFound();
            }

            service.Name = model.Name;

            await _serviceService.UpdateServiceAsync(service);

            return RedirectToAction("Admin");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteService(int id)
        {
            var service = _serviceService.GetServiceById(id);

            if (service == null)
            {
                return NotFound();
            }

            await _serviceService.DeleteServiceAsync(id);

            return RedirectToAction("Admin");
        }
        public IActionResult AddTreatment()
        {
            var model = new TreatmentDTO();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddTreatment(TreatmentDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Crearea unui nou tratament
            var treatment = new Treatment
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price
            };

            await _treatmentService.AddTreatmentAsync(treatment);

            return RedirectToAction("Admin");
        }
        [HttpGet]
        public async Task<IActionResult> EditTreatmentAsync(int id)
        {
            var treatment =  _treatmentService.GetTreatmentById(id);

            var model = new TreatmentDTO
            {
                ServiceId = treatment.ID,
                Name = treatment.Name,
                Description = treatment.Description,
                Price = treatment.Price
            };

            return await Task.FromResult<IActionResult>(View(model));
        }

        [HttpPost]
        public async Task<IActionResult> EditTreatment(TreatmentDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var treatment = _treatmentService.GetTreatmentById(model.ServiceId);

            if (treatment == null)
            {
                return NotFound();
            }

            treatment.Name = model.Name;
            treatment.Description = model.Description;
            treatment.Price = model.Price;

            await _treatmentService.UpdateTreatmentAsync(treatment);

            return RedirectToAction("Admin");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTreatment(int id)
        {
            var treatment =  _treatmentService.GetTreatmentById(id);

            if (treatment == null)
            {
                return NotFound();
            }

            await _treatmentService.DeleteTreatmentAsync(treatment.ID);

            return RedirectToAction("Admin");
        }
    }
}
