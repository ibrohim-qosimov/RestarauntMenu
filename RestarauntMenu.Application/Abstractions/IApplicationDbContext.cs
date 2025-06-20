using Microsoft.EntityFrameworkCore;
using RestarauntMenu.Domain.Entities;

namespace RestarauntMenu.Application.Abstractions;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<Food> Foods { get; set; }
    DbSet<Menu> Menus { get; set; }
    DbSet<Restaraunt> Restaraunts { get; set; }
    DbSet<MenuSection> MenuSections { get; set; }
    ValueTask<int> SaveChangesAsync(CancellationToken cancellationToken = default!);
}
