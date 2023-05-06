using Microsoft.AspNetCore.Mvc;

namespace DentalClinicWebsite.Controllers
{
    public class ServicesController : Controller
    {
        public ServicesController()
        {
        }

        public ActionResult Services()
        {

            // Pass the list of appointments to the view
            return View();
        }

    }
}