using Microsoft.AspNetCore.Mvc;

namespace MVCOutputSetup.Controllers
{
    public class Square : Controller
    {
       public IActionResult Student(int? number)
        {
            if (number == null)
                return Content("Please provide a number");
            return View(number.Value);
        }
    }
}
