using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Akelny.DAL.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_AspNetUsers_userId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_userId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Subscriptions");

            migrationBuilder.AlterColumn<string>(
                name: "TestUserID",
                table: "Subscriptions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_TestUserID",
                table: "Subscriptions",
                column: "TestUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_AspNetUsers_TestUserID",
                table: "Subscriptions",
                column: "TestUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_AspNetUsers_TestUserID",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_TestUserID",
                table: "Subscriptions");

            migrationBuilder.AlterColumn<string>(
                name: "TestUserID",
                table: "Subscriptions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Subscriptions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_userId",
                table: "Subscriptions",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_AspNetUsers_userId",
                table: "Subscriptions",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
