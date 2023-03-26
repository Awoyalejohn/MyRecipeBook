using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyRecipeBook.Migrations
{
    /// <inheritdoc />
    public partial class AddContentProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Steps");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Steps",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Steps");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Steps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
