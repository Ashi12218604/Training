using Microsoft.AspNetCore.Mvc;
using StudentMarksAPI.Data;
using System.Linq;

namespace StudentMarksAPI.Controllers
{
    public class StudentController : Controller
    {
        private readonly CollegeDbContext _context;

        public StudentController(CollegeDbContext context)
        {
            _context = context;
        }

        // MVC View
        public IActionResult Index()
        {
            return View();
        }

        // API Endpoint
        [HttpGet]
        [Route("api/students")]
        public IActionResult GetStudents()
        {
            var students = _context.Students.Select(s => new
            {
                s.Id,
                s.Name,
                s.M1,
                s.M2,
                Total = (s.M1 ?? 0) + (s.M2 ?? 0),
                Grade = CalculateGrade((s.M1 ?? 0) + (s.M2 ?? 0))
            }).ToList();

            return Ok(students);
        }

        private static string CalculateGrade(int total)
        {
            if (total >= 180) return "A";
            if (total >= 150) return "B";
            if (total >= 100) return "C";
            return "Fail";
        }
    }
}