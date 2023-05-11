using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinicWebsite.Controllers
{
    public class PricesController : Controller
    {
        public PricesController()
        {
        }
        [AllowAnonymous]
        public ActionResult Prices()
        {

            // Pass the list of appointments to the view
            return View();
        }

    }
}