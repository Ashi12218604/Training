using Microsoft.AspNetCore.Mvc;
using MVC_CRUDLPU.Models;
using System.Linq;

namespace MVC_CRUDLPU.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        // ================= READ =================
        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }

        // ================= CREATE =================
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
                return View(student);

            _context.Students.Add(student);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // ================= EDIT =================
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var student = _context.Students.Find(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            if (!ModelState.IsValid)
                return View(student);

            var existingStudent = _context.Students.Find(student.Id);

            if (existingStudent == null)
                return NotFound();

            existingStudent.Name = student.Name;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // ================= DELETE =================
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var student = _context.Students.Find(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}