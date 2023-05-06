using DentalClinicWebsite.Models;

namespace DentalClinicWebsite.Repository.Interfaces
{
    public interface IReviewRepository
    {
        IEnumerable<Review> GetAllReviews();
        Review GetReviewById(int id);
        void AddReview(Review review);
        void UpdateReview(Review review);
        void DeleteReview(int id);
    }
}
