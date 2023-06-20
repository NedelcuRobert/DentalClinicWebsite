using DentalClinicWebsite.Models;

namespace DentalClinicWebsite.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(string userId);
        Task<IEnumerable<User>> GetUsersInRoleAsync(string roleName);
        Task<bool> AddUserToRoleAsync(string userId, string roleName);
        Task<bool> RemoveUserFromRoleAsync(string userId, string roleName);
        Task<bool> UpdateUserAsync(User updatedUser, string newRole, int specializationId);
        Task<bool> DeleteUserAsync(string userId);
    }
}
