using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RestarauntMenu.Application.Abstractions;
using RestarauntMenu.Domain.Entities;
using RestarauntMenu.Domain.Enums;

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
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var passwordHasher = new PasswordHasher<User>();
            var superAdmin = new User
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Name = "Default Super Admin",
                PhoneNumber = "+998774194249",
                Role = UserRole.SuperAdmin,
            };
            superAdmin.PasswordHash = passwordHasher.HashPassword(superAdmin, "Admin01!");

            modelBuilder.Entity<User>().HasData(superAdmin);
        }

        async ValueTask<int> IApplicationDbContext.SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
