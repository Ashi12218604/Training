using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
