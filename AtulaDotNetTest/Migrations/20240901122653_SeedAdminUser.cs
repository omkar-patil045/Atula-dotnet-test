using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtulaDotNetTest.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "admin", 0, "d1bf7ef4-0f47-47c7-ba4f-85a83c9c1096", "admin@admin.com", false, "Omkar", "Patil", false, null, null, null, "AQAAAAIAAYagAAAAEOz1/oFXdHp0cqlDG/cDqP4ag1FFMzy6McbwmxEub0bq1v/q5mZxZeqnfJuK4MBTWw==", null, false, "b69ae715-8cce-4d92-a2f1-62aa78e51856", false, "admin@admin.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin");
        }
    }
}
