using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtulaDotNetTest.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdminUser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "admin", 0, "1a987995-7c44-4633-a49c-11b0c4ddaba1", "admin@admin.com", false, "Omkar", "Patil", false, null, null, null, "AQAAAAIAAYagAAAAEE7sr9USVwtY/cVZHPhnd9eI2r2A4gEXcCitEZhZml2CkY00hcLssZVth7FpLIKAhg==", null, false, "ec218d1b-9f4b-4906-9c6f-fb7af0ca2641", false, "admin@admin.com" });
        }
    }
}
