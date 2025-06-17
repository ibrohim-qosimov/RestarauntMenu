using Microsoft.EntityFrameworkCore;
using RestarauntMenu.Application.Abstractions;
using RestarauntMenu.Domain.Entities;

namespace RestarauntMenu.Infrastructure.Persistance
{
    public class RestarauntMenuDbContext : DbContext, IApplicationDbContext
    {
        public RestarauntMenuDbContext(DbContextOptions<RestarauntMenuDbContext> options)
                : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Restaraunt> Restaraunts { get; set; }
        public DbSet<MenuSection> MenuSections { get; set; }


        async ValueTask<int> IApplicationDbContext.SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
