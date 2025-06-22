using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarauntMenu.Application.UseCases.AuthServices.AccesssAuthorizationCehckerService
{
    public interface IAccessAuthorizationChecker
    {
        Task<bool> HasAccessToFoodAsync(long foodId, long userId);
        Task<bool> HasAccessToRestaurantAsync(long resturantId, long userId);
        Task<bool> HasAccessToMenuAsync(long menuId, long userId);
        Task<bool> HasAccessToMenuSectionAsync(long menuSectionId, long userId);
    }
}
