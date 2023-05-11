using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DentalClinicWebsite.Controllers
{
    public class ServicesController : Controller
    {
        public ServicesController()
        {
        }
        [AllowAnonymous]
        public ActionResult Services()
        {

            // Pass the list of appointments to the view
            return View();
        }

    }
}