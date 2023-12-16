using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyWebAppPracting.MyAttribues
{
    public class AutiorizationAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            if (user.Claims.Count() == 0)
                context.Result = new JsonResult
                    (new { message = "did not permit authorization" }) 
                    { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}
