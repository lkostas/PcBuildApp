using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PcBuildApp.Data;
using PcBuildApp.DTO;
using PcBuildApp.Services.Interfaces;
using PcBuildApp.Repository.Interfaces;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PcBuildApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly PcBuildAppDbContext _context;
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;

        public AccountController(PcBuildAppDbContext context, IUserService userService, IUserRepository userRepository)
        {
            _context = context;
            _userService = userService;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDTO loginDto)
        {
            if (!ModelState.IsValid)
            {
                return View(loginDto);
            }

            try
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.UserName == loginDto.UserName);

                if (user == null || !VerifyPassword(loginDto.Password, user.Password))
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                    return View(loginDto);
                }

                if (!user.IsActive)
                {
                    ModelState.AddModelError("", "Account is disabled.");
                    return View(loginDto);
                }

                await SignInUserAsync(user);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred during login.");
                return View(loginDto);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegistrationDTO registrationDto)
        {
            Console.WriteLine("=== REGISTER POST CALLED ===");
            Console.WriteLine($"Username: '{registrationDto?.UserName}'");
            Console.WriteLine($"Email: '{registrationDto?.Email}'");
            Console.WriteLine($"FirstName: '{registrationDto?.FirstName}'");
            Console.WriteLine($"LastName: '{registrationDto?.LastName}'");
            Console.WriteLine($"Password: {(!string.IsNullOrEmpty(registrationDto?.Password) ? "HAS_VALUE" : "EMPTY")}");
            Console.WriteLine($"ModelState.IsValid: {ModelState.IsValid}");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("=== MODEL STATE ERRORS ===");
                foreach (var error in ModelState)
                {
                    if (error.Value.Errors.Count > 0)
                    {
                        Console.WriteLine($"{error.Key}: {string.Join(", ", error.Value.Errors.Select(e => e.ErrorMessage))}");
                    }
                }
                return View(registrationDto);
            }

            try
            {
                var hashedPassword = HashPassword(registrationDto.Password);
                var userEntity = _userRepository.UserMapper(registrationDto);
                userEntity.Password = hashedPassword;

                var user = await _userService.CreateNewUserAsync(userEntity);
                await SignInUserAsync(user);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"=== REGISTRATION ERROR: {ex.Message} ===");
                ModelState.AddModelError("", "Registration failed. Please try again.");
                return View(registrationDto);
            }
        }

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = await _userService.GetUserByIdAsync(userId);
    
            if (user == null)
            {
                return NotFound();
            }
    
            return View(user);
        }

        private async Task SignInUserAsync(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Role, user.UserRole.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        private static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }

        private static bool VerifyPassword(string password, string hashedPassword)
        {
            var hashedInput = HashPassword(password);
            return hashedInput == hashedPassword;
        }
    }
}