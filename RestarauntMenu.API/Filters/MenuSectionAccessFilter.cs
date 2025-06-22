using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RestarauntMenu.Application.UseCases.AuthServices.AccesssAuthorizationCehckerService;
using System.Security.Claims;

namespace RestarauntMenu.API.Filters
{
    public class MenuSectionAccessAttribute : TypeFilterAttribute
    {
        public MenuSectionAccessAttribute() : base(typeof(MenuSectionAccessFilter)) { }
    }


    public class MenuSectionAccessFilter : IAsyncActionFilter
    {
        private readonly IAccessAuthorizationChecker _accessChecker;

        public MenuSectionAccessFilter(IAccessAuthorizationChecker accessChecker)
        {
            _accessChecker = accessChecker;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var userId = long.Parse(context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            if (context.ActionArguments.TryGetValue("id", out var idObj) && idObj is long menuSectionId)
            {
                var hasAccess = await _accessChecker.HasAccessToMenuSectionAsync(menuSectionId, userId);
                if (!hasAccess)
                {
                    context.Result = new ForbidResult("Access denied");
                    return;
                }
            }
            await next();
        }
    }
}
