using Microsoft.EntityFrameworkCore;
using RestarauntMenu.Application.Abstractions;
using RestarauntMenu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarauntMenu.Application.UseCases.AuthServices.AccesssAuthorizationCehckerService
{
    public class AccessAuthorizationChecker : IAccessAuthorizationChecker
    {
        private readonly IApplicationDbContext _context;

        public AccessAuthorizationChecker(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> HasAccessToFoodAsync(long foodId, long userId)
        {
            var food = await _context.Foods
            .Include(f => f.MenuSection)
            .ThenInclude(ms=>ms.Menu)
            .ThenInclude(m => m.Restaraunt)
            .FirstOrDefaultAsync(f => f.Id == foodId);

            return food?.MenuSection?.Menu.Restaraunt?.UserId == userId;
        }

        public async Task<bool> HasAccessToMenuAsync(long menuId, long userId)
        {
            var menu = await _context.Menus
            .Include(m => m.Restaraunt)
            .FirstOrDefaultAsync(m => m.Id == menuId);

            return menu?.Restaraunt?.UserId == userId;
        }

        public async Task<bool> HasAccessToMenuSectionAsync(long menuSectionId, long userId)
        {
            var menuSection = await _context.MenuSections
                .Include(ms=>ms.Menu)
                .ThenInclude(m=>m.Restaraunt)
                .FirstOrDefaultAsync(ms=>ms.Id == menuSectionId);

            return menuSection?.Menu?.Restaraunt?.UserId == userId;
        }   

        public async Task<bool> HasAccessToRestaurantAsync(long resturantId, long userId)
        {
            var restaurant = await _context.Restaraunts
                .FirstOrDefaultAsync(r => r.Id == resturantId);

            return restaurant?.UserId == userId;
        }
    }
}
