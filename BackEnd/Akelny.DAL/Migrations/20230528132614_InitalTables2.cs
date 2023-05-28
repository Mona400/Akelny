using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Akelny.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitalTables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_and_Dates_Subscriptions_Sub_ID",
                table: "Meals_and_Dates");

            migrationBuilder.AlterColumn<int>(
                name: "Sub_ID",
                table: "Meals_and_Dates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_and_Dates_Subscriptions_Sub_ID",
                table: "Meals_and_Dates",
                column: "Sub_ID",
                principalTable: "Subscriptions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_and_Dates_Subscriptions_Sub_ID",
                table: "Meals_and_Dates");

            migrationBuilder.AlterColumn<int>(
                name: "Sub_ID",
                table: "Meals_and_Dates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_and_Dates_Subscriptions_Sub_ID",
                table: "Meals_and_Dates",
                column: "Sub_ID",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
