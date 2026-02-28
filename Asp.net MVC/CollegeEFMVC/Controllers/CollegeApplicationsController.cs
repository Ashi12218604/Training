using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CollegeEFMVC.Data;
using CollegeEFMVC.Models;

namespace CollegeEFMVC.Controllers
{
    public class CollegeApplicationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CollegeApplicationsController(
            ApplicationDbContext context,
            IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // ================= INDEX =================
        public async Task<IActionResult> Index()
        {
            return View(await _context.CollegeApplications.ToListAsync());
        }

        // ================= DETAILS =================
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var application = await _context.CollegeApplications
                .FirstOrDefaultAsync(m => m.ApplicationId == id);

            if (application == null) return NotFound();

            return View(application);
        }

        // ================= CREATE (GET) =================
        public IActionResult Create()
        {
            return View();
        }

        // ================= CREATE (POST) =================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CollegeApplication model)
        {
            // ---------- AGE VALIDATION ----------
            int age = DateTime.Today.Year - model.DateOfBirth.Year;
            if (model.DateOfBirth > DateTime.Today.AddYears(-age)) age--;

            if (age < 18)
                ModelState.AddModelError("DateOfBirth", "Applicant must be at least 18 years old");

            // ---------- UNIQUENESS CHECKS ----------
            if (await _context.CollegeApplications.AnyAsync(x => x.Email == model.Email))
                ModelState.AddModelError("Email", "Email already registered");

            if (await _context.CollegeApplications.AnyAsync(x => x.Phone == model.Phone))
                ModelState.AddModelError("Phone", "Phone number already registered");

            if (await _context.CollegeApplications.AnyAsync(x => x.AadhaarNumber == model.AadhaarNumber))
                ModelState.AddModelError("AadhaarNumber", "Aadhaar already registered");

            // ---------- PHOTO VALIDATION ----------
            if (model.PhotoFile != null)
            {
                var allowedTypes = new[] { "image/jpeg", "image/png" };

                if (!allowedTypes.Contains(model.PhotoFile.ContentType))
                    ModelState.AddModelError("PhotoFile", "Only JPG or PNG allowed");

                if (model.PhotoFile.Length > 2 * 1024 * 1024)
                    ModelState.AddModelError("PhotoFile", "Max photo size is 2 MB");
            }

            if (!ModelState.IsValid)
                return View(model);

            // ---------- SAVE PHOTO ----------
            if (model.PhotoFile != null)
            {
                string uploadDir = Path.Combine(_env.WebRootPath, "uploads");
                Directory.CreateDirectory(uploadDir);

                string fileName = Guid.NewGuid() + Path.GetExtension(model.PhotoFile.FileName);
                string filePath = Path.Combine(uploadDir, fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                await model.PhotoFile.CopyToAsync(stream);

                model.PhotoPath = "/uploads/" + fileName;
            }
            string uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

            if (!Directory.Exists(uploadDir))
            {
                Directory.CreateDirectory(uploadDir);
            }

            _context.Add(model);
            await _context.SaveChangesAsync();

            // 👉 Redirect to Success Page
            return RedirectToAction("Success", new { id = model.ApplicationId });
        }

        // ================= SUCCESS PAGE =================
        public async Task<IActionResult> Success(int id)
        {
            var application = await _context.CollegeApplications.FindAsync(id);
            if (application == null) return NotFound();

            return View(application);
        }

        // ================= EDIT (GET) =================
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var application = await _context.CollegeApplications.FindAsync(id);
            if (application == null) return NotFound();

            return View(application);
        }

        // ================= EDIT (POST) =================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CollegeApplication model)
        {
            if (id != model.ApplicationId)
                return NotFound();

            // ---------- AGE ----------
            int age = DateTime.Today.Year - model.DateOfBirth.Year;
            if (model.DateOfBirth > DateTime.Today.AddYears(-age)) age--;

            if (age < 18)
                ModelState.AddModelError("DateOfBirth", "Applicant must be at least 18 years old");

            // ---------- DUPLICATE CHECK (EXCLUDING SELF) ----------
            if (await _context.CollegeApplications.AnyAsync(
                x => x.Email == model.Email && x.ApplicationId != model.ApplicationId))
                ModelState.AddModelError("Email", "Email already registered");

            if (await _context.CollegeApplications.AnyAsync(
                x => x.Phone == model.Phone && x.ApplicationId != model.ApplicationId))
                ModelState.AddModelError("Phone", "Phone already registered");

            if (await _context.CollegeApplications.AnyAsync(
                x => x.AadhaarNumber == model.AadhaarNumber && x.ApplicationId != model.ApplicationId))
                ModelState.AddModelError("AadhaarNumber", "Aadhaar already registered");

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

        // ================= DELETE =================
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var application = await _context.CollegeApplications
                .FirstOrDefaultAsync(m => m.ApplicationId == id);

            if (application == null) return NotFound();

            return View(application);
        }

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