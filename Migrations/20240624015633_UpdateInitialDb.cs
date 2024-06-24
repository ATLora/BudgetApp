using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Users_UserId",
                table: "Goals");

            migrationBuilder.RenameColumn(
                name: "setRecurrentDay",
                table: "Incomes",
                newName: "SetRecurrentDay");

            migrationBuilder.RenameColumn(
                name: "setRecurrentDay",
                table: "Expenses",
                newName: "SetRecurrentDay");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Goals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Users_UserId",
                table: "Goals",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Users_UserId",
                table: "Goals");

            migrationBuilder.RenameColumn(
                name: "SetRecurrentDay",
                table: "Incomes",
                newName: "setRecurrentDay");

            migrationBuilder.RenameColumn(
                name: "SetRecurrentDay",
                table: "Expenses",
                newName: "setRecurrentDay");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Goals",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Users_UserId",
                table: "Goals",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
