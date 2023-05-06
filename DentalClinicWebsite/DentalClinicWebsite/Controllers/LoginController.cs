using Microsoft.AspNetCore.Mvc;

namespace DentalClinicWebsite.Controllers
{
    public class LoginController : Controller
    {
        public LoginController()
        {
        }

        public ActionResult Login()
        {

            // Pass the list of appointments to the view
            return View();
        }

    }
}