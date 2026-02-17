using Microsoft.AspNetCore.Mvc;

namespace MVCOutputSetup.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Student()
        {
            var s = new
            {
                Name = "Ravi",
                Age = 20
            };

            return Json(s);
        }

    }
}
