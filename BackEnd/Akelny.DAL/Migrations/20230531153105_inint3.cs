using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Akelny.DAL.Migrations
{
    /// <inheritdoc />
    public partial class inint3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_and_Dates_Subscriptions_Sub_ID",
                table: "Meals_and_Dates");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_AspNetUsers_TestUserID",
                table: "Subscriptions");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_and_Dates_Subscriptions_Sub_ID",
                table: "Meals_and_Dates",
                column: "Sub_ID",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_AspNetUsers_TestUserID",
                table: "Subscriptions",
                column: "TestUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_and_Dates_Subscriptions_Sub_ID",
                table: "Meals_and_Dates");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_AspNetUsers_TestUserID",
                table: "Subscriptions");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_and_Dates_Subscriptions_Sub_ID",
                table: "Meals_and_Dates",
                column: "Sub_ID",
                principalTable: "Subscriptions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_AspNetUsers_TestUserID",
                table: "Subscriptions",
                column: "TestUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
