using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DentalClinicWebsite.Models;
using DentalClinicWebsite.Services.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Authorization;

namespace DentalClinicWebsite.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            // Create new user
            var result = await _userService.CreateUserAsync(user);

            if (result == false)
            {
                ModelState.AddModelError(string.Empty, "A apărut o eroare la înregistrare.");
                return View(user);
            }

            // Redirect to login page
            return RedirectToAction("", "Login");
        }


        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User model, string returnUrl)
        {
            // Authenticate user
            var user = await _userService.Authenticate(model.Email, model.PasswordHash);

            if (user != null)
            {
                // Create claims for user
                var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
        new Claim(ClaimTypes.Name, user.Email)
    };

                // Create identity for user
                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // Create principal for user
                var authProperties = new AuthenticationProperties();
                var principal = new ClaimsPrincipal(claimsIdentity);

                // Sign in user
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    principal, authProperties);

                return RedirectToAction("", "Account");
            }
            else
            {
                ModelState.AddModelError("", "Email-ul sau parola sunt incorecte.");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("", "Login");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile(User user)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userService.GetByIdAsync(user.ID);
                if (currentUser == null)
                {
                    return NotFound();
                }

                currentUser.FirstName = user.FirstName;
                currentUser.LastName = user.LastName;
                currentUser.Email = user.Email;
                currentUser.PasswordHash = user.PasswordHash;
                currentUser.PhoneNumber = user.PhoneNumber;
                currentUser.Address = user.Address;

                await _userService.UpdateUserAsync(currentUser);

                ViewBag.SuccessMessage = "Informațiile personale au fost actualizate cu succes!";
            }
            else
            {
                ViewBag.ErrorMessage = "A apărut o eroare la actualizarea informațiilor personale. Vă rugăm să încercați din nou.";
            }

            return View(user);
        }
    }

}

