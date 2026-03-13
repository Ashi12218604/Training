using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterAuthorizationDemo.Attributes
{
    public class AdminAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var role = context.HttpContext.Request.Headers["role"];

            if (role != "admin")
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}