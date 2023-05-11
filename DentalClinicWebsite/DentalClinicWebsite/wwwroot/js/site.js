// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
if (result.Succeeded) {
    _logger.LogInformation("User logged in.");
    document.getElementById("login-success-message").style.display = "block";
    setTimeout(function () {
        document.getElementById("login-success-message").style.display = "none";
    }, 3000); // 3 secunde
    return RedirectToAction("", "Home");
}