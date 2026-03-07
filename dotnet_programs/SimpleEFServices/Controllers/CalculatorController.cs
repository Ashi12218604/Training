using Microsoft.AspNetCore.Mvc;
using SimpleEFServices.Models;
using SimpleEFServices.Services;
using System.Diagnostics;

namespace SimpleEFServices.Controllers
{ 
    public class CalculatorController : Controller
    {
        private readonly CalculatorService _calculator;
        public CalculatorController(CalculatorService calculator)
        {
            _calculator = calculator;
        }
        public IActionResult Add(int a, int b)
        {
            var result = _calculator.Add(a, b);
            return Content($"The sum of {a} and {b} is {result}");
        }
        public IActionResult Multiply(int a, int b)
        {
            var result = _calculator.Multiply(a, b);
            return Content($"The product of {a} and {b} is {result}");
        }
        public IActionResult Divide(int a, int b)
        {
            if (b == 0)
            {
                return Content("Cannot divide by zero.");
            }
            var result = _calculator.Divide(a, b);
            return Content($"The quotient of {a} and {b} is {result}");
        }
    }
}
