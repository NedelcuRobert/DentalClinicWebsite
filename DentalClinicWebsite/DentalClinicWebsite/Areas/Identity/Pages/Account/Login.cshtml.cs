// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DentalClinicWebsite.Models.DTOs;
using DentalClinicWebsite.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace DentalClinicWebsite.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {

        [BindProperty]
        public LoginDTO Input { get; set; }

        private readonly ILoginService _loginService;

        public IEnumerable<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        public LoginModel(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            if (User.Identity.IsAuthenticated)
            {
                //_notifyService.AddNotification("You are already signed in!");
                return RedirectToAction("", "Home");
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = await _loginService.GetExternalAuthenticationSchemesAsync();

            ReturnUrl = returnUrl;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            ExternalLogins = await _loginService.GetExternalAuthenticationSchemesAsync();

            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _loginService.LoginAsync(Input.Email, Input.Password, Input.RememberMe);

                    if (result.Succeeded)
                    {
                        TempData["Message"] = "Autentificare cu succes";
                        //_notifyService.AddNotification("You have successfully logged in to your account.");
                        return RedirectToAction("", "Home");
                    }
                    if (result.IsLockedOut)
                    {
                        ModelState.AddModelError(string.Empty, "Account blocked");
                        //_notifyService.AddNotification("This account is locked. Contact support");
                        return RedirectToPage("./Lockout");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return Page();
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return Page();
        }
    }
}
