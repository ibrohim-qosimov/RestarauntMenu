using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RestarauntMenu.Application.UseCases.AuthServices.AccesssAuthorizationCehckerService;
using System.Security.Claims;

namespace RestarauntMenu.API.Filters
{

    public class MenuAccessAttribute : TypeFilterAttribute
    {
        public MenuAccessAttribute() : base(typeof(MenuAccessFilter)) { }
    }

    public class MenuAccessFilter : IAsyncActionFilter
    {
        private readonly IAccessAuthorizationChecker _accessAuthorizationChecker;

        public MenuAccessFilter(IAccessAuthorizationChecker accessAuthorizationChecker)
        {
            _accessAuthorizationChecker = accessAuthorizationChecker;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var userId = long.Parse(context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            if (context.ActionArguments.TryGetValue("id", out var idObj) && idObj is long menuId)
            {
                var hasAccess = await _accessAuthorizationChecker.HasAccessToMenuAsync(menuId, userId);
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
