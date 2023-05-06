using DentalClinicWebsite.Models;

namespace DentalClinicWebsite.Services.Interfaces
{
    public interface IReviewService
    {
        IEnumerable<Review> GetAllReviews();
        Review GetReviewById(int id);
        void AddReview(Review review);
        void UpdateReview(Review review);
        void DeleteReview(int id);
    }
}
