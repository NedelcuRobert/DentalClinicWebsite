using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using DentalClinicWebsite.Models;
using MailKit.Security;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace DentalClinicWebsite.Controllers
{
    public class ContactController : Controller
    {
        private readonly IConfiguration _config;

    public ContactController(IConfiguration config)
        {
        _config = config;
    }

        [Authorize(Roles = "User")]
        public ActionResult Contact()
        {

            // Pass the list of appointments to the view
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendMessage(Contact form)
        {
            if (ModelState.IsValid)
            {
                // Compose the message
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(form.Name, form.Email));
                message.To.Add(new MailboxAddress("Robert Nedelcu", "nedelcurobert62@gmail.com"));
                message.Subject = form.Subject;

                message.Body = new TextPart("plain")
                {
                    Text = form.Message
                };

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    client.Connect(_config["MailSettings:SmtpServer"], int.Parse(_config["MailSettings:SmtpPort"]), SecureSocketOptions.StartTls);
                    client.Authenticate(_config["MailSettings:Username"], _config["MailSettings:Password"]);
                    client.Send(message);
                    client.Disconnect(true);
                }

                TempData["SuccessMessage"] = "Mesajul a fost trimis cu succes!";
            }

            return View(form);
        }
    }
}