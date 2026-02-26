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

        // GET: CollegeApplications
        public async Task<IActionResult> Index()
        {
            return View(await _context.CollegeApplications.ToListAsync());
        }

        // GET: CollegeApplications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var application = await _context.CollegeApplications
                .FirstOrDefaultAsync(m => m.ApplicationId == id);

            if (application == null) return NotFound();

            return View(application);
        }

        // GET: CollegeApplications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CollegeApplications/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CollegeApplication model)
        {
            // 🔹 AGE VALIDATION (Backend – cannot be bypassed)
            int age = DateTime.Today.Year - model.DateOfBirth.Year;
            if (model.DateOfBirth > DateTime.Today.AddYears(-age))
                age--;

            if (age < 18)
            {
                ModelState.AddModelError("DateOfBirth", "Applicant must be at least 18 years old");
            }

            // 🔹 EMAIL UNIQUENESS CHECK
            if (await _context.CollegeApplications.AnyAsync(x => x.Email == model.Email))
            {
                ModelState.AddModelError("Email", "This email is already registered");
            }

            // 🔹 PHONE UNIQUENESS CHECK
            if (await _context.CollegeApplications.AnyAsync(x => x.Phone == model.Phone))
            {
                ModelState.AddModelError("Phone", "This phone number is already registered");
            }

            if (!ModelState.IsValid)
                return View(model);

            try
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save record. Please check unique fields.");
                return View(model);
            }
        }

        // GET: CollegeApplications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var application = await _context.CollegeApplications.FindAsync(id);
            if (application == null) return NotFound();

            return View(application);
        }

        // POST: CollegeApplications/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CollegeApplication model)
        {
            if (id != model.ApplicationId)
                return NotFound();

            // 🔹 AGE CHECK
            int age = DateTime.Today.Year - model.DateOfBirth.Year;
            if (model.DateOfBirth > DateTime.Today.AddYears(-age))
                age--;

            if (age < 18)
            {
                ModelState.AddModelError("DateOfBirth", "Applicant must be at least 18 years old");
            }

            // 🔹 EMAIL DUPLICATE (exclude current record)
            if (await _context.CollegeApplications.AnyAsync(
                x => x.Email == model.Email && x.ApplicationId != model.ApplicationId))
            {
                ModelState.AddModelError("Email", "This email is already registered");
            }

            // 🔹 PHONE DUPLICATE (exclude current record)
            if (await _context.CollegeApplications.AnyAsync(
                x => x.Phone == model.Phone && x.ApplicationId != model.ApplicationId))
            {
                ModelState.AddModelError("Phone", "This phone number is already registered");
            }

            if (!ModelState.IsValid)
                return View(model);

            try
            {
                _context.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Update failed due to duplicate values.");
                return View(model);
            }
        }

        // GET: CollegeApplications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var application = await _context.CollegeApplications
                .FirstOrDefaultAsync(m => m.ApplicationId == id);

            if (application == null) return NotFound();

            return View(application);
        }

        // POST: CollegeApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var application = await _context.CollegeApplications.FindAsync(id);
            if (application != null)
            {
                _context.CollegeApplications.Remove(application);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}