using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RestarauntMenu.Application.UseCases.AuthServices.AccesssAuthorizationCehckerService;
using System.Security.Claims;

namespace RestarauntMenu.API.Filters
{

    public class RestaurantAccessAttribute : TypeFilterAttribute
    {
        public RestaurantAccessAttribute() : base(typeof(RestaurantAccessFilter)) { }
    }

    public class RestaurantAccessFilter : IAsyncActionFilter
    {
        private readonly IAccessAuthorizationChecker _accessAuthorizationChecker;

        public RestaurantAccessFilter(IAccessAuthorizationChecker accessAuthorizationChecker)
        {
            _accessAuthorizationChecker = accessAuthorizationChecker;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var userId = long.Parse(context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            if (context.ActionArguments.TryGetValue("id", out var idObj) && idObj is long restaurantId)
            {
                var hasAccess = await _accessAuthorizationChecker.HasAccessToRestaurantAsync(restaurantId, userId);
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
