using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PcBuildApp.Data;

namespace PcBuildApp.Controllers
{
    public class ComponentsController : Controller
    {
        private readonly PcBuildAppDbContext _context;

        public ComponentsController(PcBuildAppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string search, int? categoryId, string stockFilter, string sortBy)
        {
            try
            {
                var query = _context.Components.Where(c => c.IsActive);

                // Apply search filter
                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(c => c.Name.Contains(search) || 
                                           (c.Description != null && c.Description.Contains(search)) ||
                                           (c.Model != null && c.Model.Contains(search)));
                    ViewBag.CurrentSearch = search;
                }

                // Apply category filter
                if (categoryId.HasValue)
                {
                    query = query.Where(c => c.CategoryId == categoryId.Value);
                    ViewBag.CurrentCategory = categoryId.Value;
                }

                // Apply stock filter
                if (!string.IsNullOrEmpty(stockFilter))
                {
                    switch (stockFilter.ToLower())
                    {
                        case "instock":
                            query = query.Where(c => c.IsInStock);
                            break;
                        case "outofstock":
                            query = query.Where(c => !c.IsInStock);
                            break;
                    }
                    ViewBag.CurrentStockFilter = stockFilter;
                }

                // Apply sorting
                switch (sortBy?.ToLower())
                {
                    case "price_asc":
                        query = query.OrderBy(c => c.Price);
                        break;
                    case "price_desc":
                        query = query.OrderByDescending(c => c.Price);
                        break;
                    case "name_asc":
                        query = query.OrderBy(c => c.Name);
                        break;
                    case "name_desc":
                        query = query.OrderByDescending(c => c.Name);
                        break;
                    default:
                        query = query.OrderByDescending(c => c.InsertedAt);
                        break;
                }

                var components = await query.ToListAsync();
                var categories = await _context.Categories.Where(c => c.IsActive).ToListAsync();
                var manufacturers = await _context.Manufacturers.Where(m => m.IsActive).ToListAsync();

                ViewBag.Categories = categories;
                ViewBag.Manufacturers = manufacturers;
                ViewBag.CurrentSort = sortBy;
                ViewBag.TotalComponents = components.Count;

                return View(components);
            }
            catch (Exception ex)
            {
                return View(new List<Component>());
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var component = await _context.Components
                    .FirstOrDefaultAsync(c => c.Id == id && c.IsActive);

                if (component == null)
                {
                    return NotFound();
                }

                // Get category and manufacturer info
                var category = await _context.Categories.FindAsync(component.CategoryId);
                var manufacturer = await _context.Manufacturers.FindAsync(component.ManufacturerId);

                // Get related components from same category
                var relatedComponents = await _context.Components
                    .Where(c => c.CategoryId == component.CategoryId && 
                               c.Id != component.Id && 
                               c.IsActive)
                    .Take(4)
                    .ToListAsync();

                ViewBag.Category = category;
                ViewBag.Manufacturer = manufacturer;
                ViewBag.RelatedComponents = relatedComponents;

                return View(component);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> ByCategory(int categoryId)
        {
            try
            {
                var category = await _context.Categories.FindAsync(categoryId);
                if (category == null)
                {
                    return NotFound();
                }

                var components = await _context.Components
                    .Where(c => c.CategoryId == categoryId && c.IsActive)
                    .OrderByDescending(c => c.InsertedAt)
                    .ToListAsync();

                ViewBag.CategoryName = category.Name;
                ViewBag.CategoryId = categoryId;

                return View("Index", components);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        // NEW METHOD: API endpoint for PC Building Simulator
        [HttpGet]
        public async Task<IActionResult> GetComponentsByCategory(int categoryId)
        {
            try
            {
                var components = await _context.Components
                    .Where(c => c.CategoryId == categoryId && c.IsActive)
                    .Select(c => new {
                        c.Id,
                        c.Name,
                        c.Price,
                        Power = c.TDP ?? 0, // Power consumption
                        Performance = 85 // Default performance value for now
                    })
                    .ToListAsync();

                return Json(components);
            }
            catch (Exception ex)
            {
                return Json(new List<object>());
            }
        }
    }
}