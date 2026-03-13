using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterAuthorizationDemo.Filters
{
    public class LoggingActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Request Started: " + context.HttpContext.Request.Path);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Request Finished");
        }
    }
}