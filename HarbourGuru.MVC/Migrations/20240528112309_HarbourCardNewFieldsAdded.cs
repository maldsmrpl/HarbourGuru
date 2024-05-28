using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HarbourGuru.MVC.Migrations
{
    /// <inheritdoc />
    public partial class HarbourCardNewFieldsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "HarbourCards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "HarbourCards",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "HarbourCards");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "HarbourCards");
        }
    }
}
