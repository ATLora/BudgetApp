using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetApp.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectedAmountToExpenseAndIncome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Incomes",
                newName: "RealAmount");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Expenses",
                newName: "RealAmount");

            migrationBuilder.AddColumn<decimal>(
                name: "AccountsBalance",
                table: "Users",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ProjectedAmount",
                table: "Incomes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ProjectedAmount",
                table: "Expenses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountsBalance",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProjectedAmount",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "ProjectedAmount",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "RealAmount",
                table: "Incomes",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "RealAmount",
                table: "Expenses",
                newName: "Amount");
        }
    }
}
