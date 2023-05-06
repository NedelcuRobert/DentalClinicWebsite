using Microsoft.AspNetCore.Mvc;

namespace DentalClinicWebsite.Controllers
{
    public class TeamController : Controller
    {
        public TeamController()
        {
        }

        public ActionResult Team()
        {

            // Pass the list of appointments to the view
            return View();
        }

    }
}
