using Microsoft.AspNetCore.Mvc;
using MVC_Adonet.Data;  

namespace MVC_Adonet.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRepository _repo;

        public StudentController(StudentRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var students = _repo.GetAllStudents();
            return View(students);
        }
    }
}
