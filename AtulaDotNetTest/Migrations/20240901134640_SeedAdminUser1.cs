using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtulaDotNetTest.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdminUser1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a987995-7c44-4633-a49c-11b0c4ddaba1", "AQAAAAIAAYagAAAAEE7sr9USVwtY/cVZHPhnd9eI2r2A4gEXcCitEZhZml2CkY00hcLssZVth7FpLIKAhg==", "ec218d1b-9f4b-4906-9c6f-fb7af0ca2641" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1bf7ef4-0f47-47c7-ba4f-85a83c9c1096", "AQAAAAIAAYagAAAAEOz1/oFXdHp0cqlDG/cDqP4ag1FFMzy6McbwmxEub0bq1v/q5mZxZeqnfJuK4MBTWw==", "b69ae715-8cce-4d92-a2f1-62aa78e51856" });
        }
    }
}
