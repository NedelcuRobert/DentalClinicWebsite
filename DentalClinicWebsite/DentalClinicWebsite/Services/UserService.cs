using DentalClinicWebsite.Models;
using DentalClinicWebsite.Repositories;
using DentalClinicWebsite.Repository.Interfaces;
using DentalClinicWebsite.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace DentalClinicWebsite.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserSpecializationRepository _userSpecializationRepository;

        public UserService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IUserSpecializationRepository userSpecializationRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userSpecializationRepository = userSpecializationRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<IEnumerable<User>> GetUsersInRoleAsync(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role != null)
            {
                return await _userManager.GetUsersInRoleAsync(role.Name);
            }
            return null;
        }

        public async Task<bool> AddUserToRoleAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.AddToRoleAsync(user, roleName);
                return result.Succeeded;
            }
            return false;
        }

        public async Task<bool> RemoveUserFromRoleAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.RemoveFromRoleAsync(user, roleName);
                return result.Succeeded;
            }
            return false;
        }

        public async Task<bool> UpdateUserAsync(User updatedUser, string newRole, int specializationId)
        {
            var user = await _userManager.FindByIdAsync(updatedUser.Id);
            if (user == null)
            {
                return false;
            }

            user.Email = updatedUser.Email;
            user.UserName = updatedUser.UserName;

            var existingRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, existingRoles.ToArray());
            await _userManager.AddToRoleAsync(user, newRole);

            if (newRole == "Dentist")
            {
                // Verificăm dacă utilizatorul are deja o specializare asignată
                var userSpecialization = user.UserSpecializations.FirstOrDefault();
                if (userSpecialization == null)
                {
                    // Nu există specializare asignată, așa că o creăm și o asignăm
                    var specialization = await _userSpecializationRepository.GetUserSpecializationByIdAsync(specializationId);
                    if (specialization == null)
                    {
                        // Specializarea nu a fost găsită
                        return false;
                    }

                    userSpecialization = new UserSpecialization
                    {
                        UserId = user.Id,
                        SpecializationId = specializationId
                    };

                    // Adăugăm înregistrarea în repository-ul UserSpecialization și salvăm modificările
                    await _userSpecializationRepository.AddUserSpecializationAsync(userSpecialization);
                }
                else
                {
                    // Actualizăm specializarea existentă
                    userSpecialization.SpecializationId = specializationId;

                    // Actualizăm înregistrarea în repository-ul UserSpecialization
                    await _userSpecializationRepository.UpdateUserSpecializationAsync(userSpecialization);
                }
            }

            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false;
            }

            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }
    }
}
