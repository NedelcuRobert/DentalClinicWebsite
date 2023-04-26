using DentalClinicWebsite.Models;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
        private readonly DentalClinicContext _dbContext;

        public HomeController()
        {
        }

        public ActionResult Index()
        {

            // Pass the list of appointments to the view
            return View();
        }

}
