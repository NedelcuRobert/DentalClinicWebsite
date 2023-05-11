using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DentalClinicWebsite.Controllers
{
    public class TeamController : Controller
    {
        public TeamController()
        {
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Team()
        {

            // Pass the list of appointments to the view
            return View();
        }

    }
}
