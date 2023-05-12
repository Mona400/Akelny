using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Akelny.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Restaurant_RestaurantId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_RestaurantId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Sections");

            migrationBuilder.CreateTable(
                name: "RestaurantSection",
                columns: table => new
                {
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    SectionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantSection", x => new { x.RestaurantId, x.SectionsId });
                    table.ForeignKey(
                        name: "FK_RestaurantSection_Restaurant_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantSection_Sections_SectionsId",
                        column: x => x.SectionsId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantSection_SectionsId",
                table: "RestaurantSection",
                column: "SectionsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RestaurantSection");

            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "Sections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Sections",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MealId", "RestaurantId" },
                values: new object[] { 0, null });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MealId", "RestaurantId" },
                values: new object[] { 0, null });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "MealId", "RestaurantId" },
                values: new object[] { 0, null });

            migrationBuilder.CreateIndex(
                name: "IX_Sections_RestaurantId",
                table: "Sections",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Restaurant_RestaurantId",
                table: "Sections",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id");
        }
    }
}
