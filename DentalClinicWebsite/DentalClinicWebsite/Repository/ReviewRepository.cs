using DentalClinicWebsite.Models;
using DentalClinicWebsite.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DentalClinicWebsite.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DentalClinicContext _context;

        public ReviewRepository(DentalClinicContext context)
        {
            _context = context;
        }

        public IEnumerable<Review> GetAllReviews()
        {
            return _context.Reviews.Include(r => r.User);
        }

        public Review GetReviewById(int id)
        {
            return _context.Reviews.Include(r => r.User).FirstOrDefault(r => r.ID == id);
        }

        public void AddReview(Review review)
        {
            if (review == null)
            {
                throw new ArgumentNullException(nameof(review), "Review cannot be null");
            }

            if (review.Rating < 1 || review.Rating > 5)
            {
                throw new ArgumentException("Rating should be between 1 and 5");
            }

            _context.Reviews.Add(review);
            _context.SaveChanges();
        }

        public void UpdateReview(Review review)
        {
            if (review == null)
            {
                throw new ArgumentNullException(nameof(review), "Review cannot be null");
            }

            if (review.Rating < 1 || review.Rating > 5)
            {
                throw new ArgumentException("Rating should be between 1 and 5");
            }

            _context.Entry(review).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteReview(int id)
        {
            var review = _context.Reviews.Find(id);
            if (review == null)
            {
                throw new ArgumentException("Review not found");
            }

            _context.Reviews.Remove(review);
            _context.SaveChanges();
        }
    }
}
