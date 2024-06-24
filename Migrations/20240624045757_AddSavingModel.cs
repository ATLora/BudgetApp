using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetApp.Migrations
{
    /// <inheritdoc />
    public partial class AddSavingModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Goals",
                newName: "PeriodicAmount");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "SubCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "SubCategories");

            migrationBuilder.RenameColumn(
                name: "PeriodicAmount",
                table: "Goals",
                newName: "Price");
        }
    }
}
