using DentalClinicWebsite.Models;
using DentalClinicWebsite.Repository.Interfaces;
using DentalClinicWebsite.Services.Interfaces;

namespace DentalClinicWebsite.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public IEnumerable<Review> GetAllReviews()
        {
            return _reviewRepository.GetAllReviews();
        }

        public Review GetReviewById(int id)
        {
            return _reviewRepository.GetReviewById(id);
        }

        public void AddReview(Review review)
        {
            if (review == null)
            {
                throw new ArgumentNullException(nameof(review), "Review cannot be null");
            }

            _reviewRepository.AddReview(review);
        }

        public void UpdateReview(Review review)
        {
            if (review == null)
            {
                throw new ArgumentNullException(nameof(review), "Review cannot be null");
            }

            _reviewRepository.UpdateReview(review);
        }

        public void DeleteReview(int id)
        {
            _reviewRepository.DeleteReview(id);
        }
    }
}
