using DentalClinicWebsite.Models;
using DentalClinicWebsite.Repository.Interfaces;
using DentalClinicWebsite.Repository;
using DentalClinicWebsite.Services.Interfaces;
using DentalClinicWebsite.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using DentalClinicWebsite.Models.Constraints;
using Microsoft.AspNetCore.Identity;
using Abp.Net.Mail;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DentalClinicContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DentalClinicContext")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

builder.Services.AddHttpContextAccessor();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Add authentication and authorization middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Home}/{id?}");

app.MapControllerRoute(
    name: "team",
    pattern: "{controller=Team}/{action=Team}/{id?}");

app.MapControllerRoute(
    name: "services",
    pattern: "{controller=Services}/{action=Services}/{id?}");

app.MapControllerRoute(
    name: "prices",
    pattern: "{controller=Prices}/{action=Prices}/{id?}");

app.MapControllerRoute(
    name: "schedule",
    pattern: "{controller=Schedule}/{action=Schedule}/{id?}");

app.MapControllerRoute(
    name: "contact",
    pattern: "{controller=Contact}/{action=Contact}/{id?}");

app.MapControllerRoute(
    name: "account",
    pattern: "{controller=Account}/{action=Account}/{id?}");

// Add authentication and authorization middleware for specific routes
app.MapControllerRoute(
    name: "login",
    pattern: "{controller=Login}/{action=Login}/{id?}",
    defaults: new { controller = "Login", action = "Login" },
    constraints: new { notLoggedIn = new AuthenticatedUserRouteConstraint() });

app.MapControllerRoute(
    name: "register",
    pattern: "{controller=Register}/{action=Register}/{id?}",
    defaults: new { controller = "Register", action = "Register" },
    constraints: new { notLoggedIn = new AuthenticatedUserRouteConstraint() });

app.UseStaticFiles();

app.Run();