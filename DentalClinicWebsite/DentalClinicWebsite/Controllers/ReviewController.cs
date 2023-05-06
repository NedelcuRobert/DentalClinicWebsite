using DentalClinicWebsite.Models;
using DentalClinicWebsite.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinicWebsite.Controllers
{
    [Authorize] // doar utilizatorii autentificați pot accesa ReviewController
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        public IActionResult Create(Review review)
        {
            if (ModelState.IsValid)
            {
                _reviewService.AddReview(review);
                return RedirectToAction("", "Team"); // sau orice altă acțiune dorită
            }
            return BadRequest();
        }
    }
}
