using System.Text;
using DentalClinicWebsite.Models;
using DentalClinicWebsite.Models.DTOs;
using DentalClinicWebsite.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;

namespace DentalClinicWebsite.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IUserStore<User> _userStore;
        private readonly IUserEmailStore<User> _emailStore;
        private readonly ILogger<RegisterService> _logger;

        public RegisterService(
            UserManager<User> userManager,
            IUserStore<User> userStore,
            SignInManager<User> signInManager,
            ILogger<RegisterService> logger)
            //IEmailSender emailSender)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            //_emailSender = emailSender;
        }

        public async Task<User> RegisterUserAsync(RegisterDTO input)
        {
            var user = CreateUser();

            await _userStore.SetUserNameAsync(user, input.Email, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, input.Email, CancellationToken.None);

            // Verifica daca adresa de e-mail exista deja in baza de date
            var existingUser = await _userManager.FindByEmailAsync(input.Email);

            if (existingUser != null)
            {
                _logger.LogError($"A user with email '{input.Email}' already exists.");
                throw new Exception($"A user with email '{input.Email}' already exists.");
            }

            var result = await _userManager.CreateAsync(user, input.Password);

            if (!result.Succeeded)
            {
                return new User();
            }

            _logger.LogInformation("User created a new account with password.");

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            await _userManager.ConfirmEmailAsync(user, code);

            return user;
        }

        private User CreateUser()
        {
            try
            {
                return Activator.CreateInstance<User>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(User)}'. " +
                    $"Ensure that '{nameof(User)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<User> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<User>)_userStore;
        }
    }
}
