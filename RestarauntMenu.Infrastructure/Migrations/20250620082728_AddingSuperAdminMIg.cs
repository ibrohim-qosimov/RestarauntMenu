using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestarauntMenu.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingSuperAdminMIg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Name", "PasswordHash", "PhoneNumber", "Role" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 6, 20, 8, 27, 25, 264, DateTimeKind.Utc).AddTicks(603), "Default Super Admin", "AQAAAAIAAYagAAAAEHRJqKLxwTpFQpKo4VCcDjaKW28kIt87ubcesAqpRhKTLAqPkj6RnC12kDDINUEhWw==", "+998774194249", 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
