using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CollegeEFMVC.Data;
using CollegeEFMVC.Models;

namespace CollegeEFMVC.Controllers
{
    public class CollegeApplicationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CollegeApplicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // LIST
        public async Task<IActionResult> Index()
        {
            return View(await _context.CollegeApplications.ToListAsync());
        }

        // CREATE (GET)
        public IActionResult Create()
        {
            return View();
        }

        // CREATE (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CollegeApplication model)
        {
            // AGE CHECK
            int age = DateTime.Today.Year - model.DateOfBirth.Year;
            if (model.DateOfBirth > DateTime.Today.AddYears(-age))
                age--;

            if (age < 18)
                ModelState.AddModelError("DateOfBirth", "Applicant must be at least 18 years old");

            // EMAIL UNIQUE
            if (await _context.CollegeApplications.AnyAsync(x => x.Email == model.Email))
                ModelState.AddModelError("Email", "Email already registered");

            // PHONE UNIQUE
            if (await _context.CollegeApplications.AnyAsync(x => x.Phone == model.Phone))
                ModelState.AddModelError("Phone", "Phone number already registered");

            if (!ModelState.IsValid)
                return View(model);

            _context.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}