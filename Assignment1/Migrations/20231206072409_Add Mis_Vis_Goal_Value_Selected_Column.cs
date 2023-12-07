using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment1.Migrations
{
    /// <inheritdoc />
    public partial class AddMis_Vis_Goal_Value_Selected_Column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsGoalSelected",
                table: "chairmen",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMissionSelected",
                table: "chairmen",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsValuesSelected",
                table: "chairmen",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVisionSelected",
                table: "chairmen",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "chairmen",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsGoalSelected", "IsMissionSelected", "IsValuesSelected", "IsVisionSelected" },
                values: new object[] { true, true, true, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsGoalSelected",
                table: "chairmen");

            migrationBuilder.DropColumn(
                name: "IsMissionSelected",
                table: "chairmen");

            migrationBuilder.DropColumn(
                name: "IsValuesSelected",
                table: "chairmen");

            migrationBuilder.DropColumn(
                name: "IsVisionSelected",
                table: "chairmen");
        }
    }
}
