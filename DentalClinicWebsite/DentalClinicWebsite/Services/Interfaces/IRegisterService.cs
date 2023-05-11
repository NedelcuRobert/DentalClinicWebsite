using DentalClinicWebsite.Areas.Identity.Pages.Account;
using DentalClinicWebsite.Models;
using DentalClinicWebsite.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace DentalClinicWebsite.Services.Interfaces
{
    public interface IRegisterService
    {
        Task<User> RegisterUserAsync(RegisterDTO input);
    }
}
