using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtulaDotNetTest.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdminUser4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "admin-role-id", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "admin-user-id", 0, "9fef7d82-5055-49ba-9447-fc5e072deb13", "admin@example.com", true, "Admin", "User", false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEBBUiX7Mjwycs2RVs3klN53sbds5BcY0yraFFZEpPQLIqz5OXGxhKF6OxMveYTfoTQ==", null, false, "93a72765-801e-4de3-b4a6-026392ce4df6", false, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "admin-role-id", "admin-user-id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "admin-role-id", "admin-user-id" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin-role-id");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id");
        }
    }
}
