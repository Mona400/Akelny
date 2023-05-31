using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Akelny.DAL.Migrations
{
    /// <inheritdoc />
    public partial class userIMG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileImg",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileImg",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImg",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ProfileImg",
                table: "AspNetUsers");
        }
    }
}
