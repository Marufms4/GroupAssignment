using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment1.Migrations
{
    /// <inheritdoc />
    public partial class secnd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "chairmen",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhotoPath",
                value: "chairman.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "chairmen",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhotoPath",
                value: "~/Images/chairman.png");
        }
    }
}
