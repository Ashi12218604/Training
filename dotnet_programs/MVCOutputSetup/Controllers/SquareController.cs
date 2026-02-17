using Microsoft.AspNetCore.Mvc;

namespace MVCOutputSetup.Controllers
{
    public class SquareController : Controller
    {
        public IActionResult Square(int number)
        {
            return View(number);
        }
    }
}
