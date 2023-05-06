using Microsoft.AspNetCore.Mvc;

namespace DentalClinicWebsite.Controllers
{
    public class RegisterController : Controller
    {
        public RegisterController()
        {
        }

        public ActionResult Register()
        {

            // Pass the list of appointments to the view
            return View();
        }

    }
}