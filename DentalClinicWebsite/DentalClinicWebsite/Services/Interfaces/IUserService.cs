using DentalClinicWebsite.Models;
using System.Collections;

namespace DentalClinicWebsite.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetByIdAsync(int id);
        Task<User> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllAsync();
        Task<bool> CreateUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(User user);
        Task<User> Authenticate(string email, string password);
    }
}
