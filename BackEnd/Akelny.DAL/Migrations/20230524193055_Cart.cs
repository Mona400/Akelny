using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Akelny.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Cart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Meals_and_Dates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PaymentDetails",
                columns: table => new
                {
                    VisaNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CardVerificationValue = table.Column<int>(type: "int", nullable: false),
                    HolderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisaExpirationDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetails", x => x.VisaNumber);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MonthlyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDetailsVisaNumber = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_PaymentDetails_PaymentDetailsVisaNumber",
                        column: x => x.PaymentDetailsVisaNumber,
                        principalTable: "PaymentDetails",
                        principalColumn: "VisaNumber");
                });

            migrationBuilder.UpdateData(
                table: "Meals_and_Dates",
                keyColumn: "ID",
                keyValue: 1,
                column: "CartId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Meals_and_Dates_CartId",
                table: "Meals_and_Dates",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_PaymentDetailsVisaNumber",
                table: "Carts",
                column: "PaymentDetailsVisaNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_and_Dates_Carts_CartId",
                table: "Meals_and_Dates",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_and_Dates_Carts_CartId",
                table: "Meals_and_Dates");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "PaymentDetails");

            migrationBuilder.DropIndex(
                name: "IX_Meals_and_Dates_CartId",
                table: "Meals_and_Dates");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Meals_and_Dates");
        }
    }
}
