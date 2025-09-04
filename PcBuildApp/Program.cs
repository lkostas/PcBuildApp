using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using PcBuildApp.Data;
using PcBuildApp.Repository.Interfaces;
using PcBuildApp.Repository.Implementations;
using PcBuildApp.Services.Interfaces;
using PcBuildApp.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add MVC and API support
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

// Add Entity Framework and PostgreSQL
builder.Services.AddDbContext<PcBuildAppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Repository Services
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBuildRepository, BuildRepository>();


// Register Business Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBuildService, BuildService>();

// Simple Cookie Authentication for web pages
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.ExpireTimeSpan = TimeSpan.FromDays(7);
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Map controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();