using DentalClinicWebsite.Models;
using DentalClinicWebsite.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DentalClinicWebsite.Repository
{
    public class UserSpecializationRepository : IUserSpecializationRepository
    {
        private readonly DentalClinicContext _dbContext;

        public UserSpecializationRepository(DentalClinicContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserSpecialization>> GetAllAsync()
        {
            return await _dbContext.UserSpecializations
                .Include(us => us.User)
                .Include(us => us.Specialization)
                .ToListAsync();
        }

        public async Task<UserSpecialization> GetByIdAsync(int id)
        {
            return await _dbContext.UserSpecializations.FindAsync(id);
        }

        public async Task<List<UserSpecialization>> GetByUserIdAsync(int userId)
        {
            return await _dbContext.UserSpecializations
                .Include(us => us.User)
                .Include(us => us.Specialization)
                .Where(us => us.UserId == userId)
                .ToListAsync();
        }

        public async Task<List<UserSpecialization>> GetBySpecializationIdAsync(int specializationId)
        {
            return await _dbContext.UserSpecializations
                .Include(us => us.User)
                .Include(us => us.Specialization)
                .Where(us => us.SpecializationId == specializationId)
                .ToListAsync();
        }

        public async Task<UserSpecialization> AddAsync(UserSpecialization userSpecialization)
        {
            _dbContext.UserSpecializations.Add(userSpecialization);
            await _dbContext.SaveChangesAsync();
            return userSpecialization;
        }

        public async Task<UserSpecialization> UpdateAsync(UserSpecialization userSpecialization)
        {
            _dbContext.Entry(userSpecialization).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return userSpecialization;
        }

        public async Task DeleteAsync(UserSpecialization userSpecialization)
        {
            _dbContext.UserSpecializations.Remove(userSpecialization);
            await _dbContext.SaveChangesAsync();
        }
    }
}
