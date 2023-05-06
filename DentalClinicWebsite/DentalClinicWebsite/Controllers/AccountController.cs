using Microsoft.AspNetCore.Mvc;

namespace DentalClinicWebsite.Controllers
{
    public class AccountController : Controller
    {
        public AccountController()
        {
        }

        public ActionResult Account()
        {

            // Pass the list of appointments to the view
            return View();
        }

    }
}
