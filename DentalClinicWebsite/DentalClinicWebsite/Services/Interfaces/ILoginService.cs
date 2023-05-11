using DentalClinicWebsite.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace DentalClinicWebsite.Services.Interfaces
{
    public interface ILoginService
    {
        Task<bool> LoginByUser(User user);
        Task<SignInResult> LoginAsync(string email, string password, bool rememberMe);
        Task<IEnumerable<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync();

    }
}
