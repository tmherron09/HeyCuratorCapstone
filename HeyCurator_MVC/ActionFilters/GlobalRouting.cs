using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace HeyCurator_MVC.ActionFilters
{
    public class GlobalRouting : IActionFilter
    {
        private readonly ClaimsPrincipal _claimsPrincipal;

        public GlobalRouting(ClaimsPrincipal claimsPrincipal)
        {
            _claimsPrincipal = claimsPrincipal;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

            var controller = context.RouteData.Values["controller"];


            if (!_claimsPrincipal.Identity.IsAuthenticated)
            {
                context.Result = new RedirectResult("/Identity/Account/Login");

            }
            //Identity / Account / Login

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }



    }
}
