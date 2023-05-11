// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using DentalClinicWebsite.Models.DTOs;
using DentalClinicWebsite.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DentalClinicWebsite.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly ILoginService _loginService;
        private readonly IRegisterService _registerService;
        //private readonly INotifyService _notifyService;

        public RegisterModel(IRegisterService registerService, ILoginService loginService)
        {
            _registerService = registerService;
            _loginService = loginService;
            //_notifyService = notifyService;

        }

        [BindProperty]
        public RegisterDTO Input { get; set; }

        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                //_notifyService.AddNotification("You are already signed in!");
                return RedirectToAction("", "Home");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _registerService.RegisterUserAsync(Input);

                    if (result.Id != string.Empty)
                    {
                        await _loginService.LoginByUser(result);
                        TempData["Message"] = "Inregistrare cu succes";

                        //_notifyService.AddNotification("Your account has been created successfully.");
                        return RedirectToAction("", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Failed to register user.");
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
