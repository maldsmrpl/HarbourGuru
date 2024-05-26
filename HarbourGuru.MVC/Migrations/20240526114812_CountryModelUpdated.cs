using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HarbourGuru.MVC.Migrations
{
    /// <inheritdoc />
    public partial class CountryModelUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CountryCode",
                table: "Countries",
                newName: "CountryCodeA2");

            migrationBuilder.AddColumn<string>(
                name: "CountryCodeA3",
                table: "Countries",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CountryFlagLarge",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CountryFlagSmall",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CountryFullName",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryCodeA3",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CountryFlagLarge",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CountryFlagSmall",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CountryFullName",
                table: "Countries");

            migrationBuilder.RenameColumn(
                name: "CountryCodeA2",
                table: "Countries",
                newName: "CountryCode");
        }
    }
}
