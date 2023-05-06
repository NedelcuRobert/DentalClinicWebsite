using DentalClinicWebsite.Models;
using DentalClinicWebsite.Repository.Interfaces;
using DentalClinicWebsite.Services.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Collections;
using System.Security.Cryptography;

namespace DentalClinicWebsite.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            if (await _userRepository.GetByEmailAsync(user.Email) != null)
            {
                return false;
            }

            user.RoleId = 2; // User role ID
            user.PasswordHash = HashPassword(user.PasswordHash);

            await _userRepository.AddAsync(user);
            return true;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            var existingUser = await _userRepository.GetByIdAsync(user.ID);

            if (existingUser == null)
            {
                return false;
            }

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.Address = user.Address;
            existingUser.PasswordHash = HashPassword(user.PasswordHash);

            _userRepository.Update(existingUser);
            return true;
        }

        public async Task<bool> DeleteUserAsync(User user)
        {
            var existingUser = await _userRepository.GetByIdAsync(user.ID);

            if (existingUser == null)
            {
                return false;
            }

            _userRepository.Delete(existingUser);
            return true;
        }

        private string HashPassword(string password)
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            byte[] hash = KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA512, 10000, 32);

            return $"{Convert.ToBase64String(salt)}:{Convert.ToBase64String(hash)}";
        }

        public async Task<User> Authenticate(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);

            if (user == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(password, user.PasswordHash))
            {
                return null;
            }

            return user;
        }

        private bool VerifyPasswordHash(string password, string storedHash)
        {
            var hashParts = storedHash.Split(':');
            var salt = Convert.FromBase64String(hashParts[0]);
            var hash = Convert.FromBase64String(hashParts[1]);

            var computedHash = KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA512, 10000, 32);

            return computedHash.SequenceEqual(hash);
        }
    }
}
