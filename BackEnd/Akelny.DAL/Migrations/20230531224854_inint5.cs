using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Akelny.DAL.Migrations
{
    /// <inheritdoc />
    public partial class inint5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Restaurant_RestaurantId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_RestaurantId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Reviews");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "507a9056-bf91-4616-8036-f8443aaf41d7.jpg");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "507a9056-bf91-4616-8036-f8443aaf41d7.jpg");

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "507a9056-bf91-4616-8036-f8443aaf41d7.jpg");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RestId",
                table: "Reviews",
                column: "RestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Restaurant_RestId",
                table: "Reviews",
                column: "RestId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Restaurant_RestId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_RestId",
                table: "Reviews");

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Restaurant",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RestaurantId",
                table: "Reviews",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Restaurant_RestaurantId",
                table: "Reviews",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id");
        }
    }
}
