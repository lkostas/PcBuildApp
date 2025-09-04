using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PcBuildApp.Data;
using PcBuildApp.DTO;
using System.Security.Claims;

namespace PcBuildApp.Controllers
{
    public class BuildsController : Controller
    {
        private readonly PcBuildAppDbContext _context;

        public BuildsController(PcBuildAppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                // Get all public builds for browsing
                var publicBuilds = await _context.Builds
                    .Where(b => b.IsPublic)
                    .OrderByDescending(b => b.InsertedAt)
                    .ToListAsync();

                ViewBag.PageTitle = "Community Builds";
                return View(publicBuilds);
            }
            catch (Exception ex)
            {
                return View(new List<Build>());
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> MyBuilds()
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                
                var userBuilds = await _context.Builds
                    .Where(b => b.UserId == userId)
                    .OrderByDescending(b => b.InsertedAt)
                    .ToListAsync();

                ViewBag.PageTitle = "My Builds";
                return View("Index", userBuilds);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] BuildCreateDTO buildCreateDto)
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        
                var build = new Build
                {
                    Name = buildCreateDto.Name,
                    Description = buildCreateDto.Description,
                    TotalPrice = buildCreateDto.TotalPrice,
                    TotalWattage = buildCreateDto.TotalWattage,
                    IsPublic = buildCreateDto.IsPublic,
                    IsCompleted = buildCreateDto.IsCompleted,
                    UserId = userId
                };

                _context.Builds.Add(build);
                await _context.SaveChangesAsync();
        
                return Json(new { success = true, id = build.Id });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var build = await _context.Builds.FindAsync(id);
        
                if (build == null)
                {
                    return NotFound();
                }

                // Check if user can view this build (public or owns it)
                if (!build.IsPublic && User.Identity.IsAuthenticated)
                {
                    var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                    if (build.UserId != userId && !User.IsInRole("Admin"))
                    {
                        return Forbid();
                    }
                }
                else if (!build.IsPublic)
                {
                    return Forbid();
                }

                return View(build);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        
        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var build = await _context.Builds.FindAsync(id);
        
                if (build == null)
                {
                    return NotFound();
                }

                // Check if user owns this build or is admin
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                if (build.UserId != userId && !User.IsInRole("Admin"))
                {
                    return Forbid();
                }

                // Redirect to the build creator with the build data
                return RedirectToAction("Create", new { editId = id });
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int id, Build build)
        {
            if (id != build.Id)
            {
                return NotFound();
            }

            try
            {
                var existingBuild = await _context.Builds.FindAsync(id);
                if (existingBuild == null)
                {
                    return NotFound();
                }

                // Check ownership
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                if (existingBuild.UserId != userId && !User.IsInRole("Admin"))
                {
                    return Forbid();
                }

                // Update only editable fields
                existingBuild.Name = build.Name;
                existingBuild.Description = build.Description;
                existingBuild.IsPublic = build.IsPublic;
                existingBuild.ModifiedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                return RedirectToAction("MyBuilds");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error updating build");
                return View(build);
            }
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var build = await _context.Builds.FindAsync(id);
                
                if (build == null)
                {
                    return NotFound();
                }

                // Check if user owns this build or is admin
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                if (build.UserId != userId && !User.IsInRole("Admin"))
                {
                    return Forbid();
                }

                _context.Builds.Remove(build);
                await _context.SaveChangesAsync();

                return RedirectToAction("MyBuilds");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
        
    }
}