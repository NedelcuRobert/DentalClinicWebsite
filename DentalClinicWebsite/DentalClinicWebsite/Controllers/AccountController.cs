using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DentalClinicWebsite.Controllers
{
    public class AccountController : Controller
    {
        public AccountController()
        {
        }
        [Authorize(Roles = "Admin,User")]
        public ActionResult Account()
        {

            // Pass the list of appointments to the view
            return View();
        }

    }
}
