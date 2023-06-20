using DentalClinicWebsite.Models;
using DentalClinicWebsite.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DentalClinicWebsite.Repositories
{
    public class UserSpecializationRepository : IUserSpecializationRepository
    {
        private readonly DentalClinicContext _dbContext;

        public UserSpecializationRepository(DentalClinicContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserSpecialization> GetUserSpecializationByIdAsync(int id)
        {
            return await _dbContext.UserSpecializations.FindAsync(id);
        }

        public async Task<List<UserSpecialization>> GetUserSpecializationsByUserIdAsync(string userId)
        {
            return await _dbContext.UserSpecializations
                .Where(us => us.UserId == userId)
                .ToListAsync();
        }

        public async Task AddUserSpecializationAsync(UserSpecialization userSpecialization)
        {
            _dbContext.UserSpecializations.Add(userSpecialization);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUserSpecializationAsync(UserSpecialization userSpecialization)
        {
            _dbContext.Entry(userSpecialization).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveUserSpecializationAsync(UserSpecialization userSpecialization)
        {
            _dbContext.UserSpecializations.Remove(userSpecialization);
            await _dbContext.SaveChangesAsync();
        }
    }
}
