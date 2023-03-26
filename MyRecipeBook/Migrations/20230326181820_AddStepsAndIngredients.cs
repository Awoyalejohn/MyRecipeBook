using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyRecipeBook.Migrations
{
    /// <inheritdoc />
    public partial class AddStepsAndIngredients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Steps_RecipeId",
                table: "Steps");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Steps",
                newName: "Step1");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Ingredients",
                newName: "Ingredient1");

            migrationBuilder.AddColumn<string>(
                name: "Step2",
                table: "Steps",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Step3",
                table: "Steps",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Step4",
                table: "Steps",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Step5",
                table: "Steps",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ingredient10",
                table: "Ingredients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ingredient2",
                table: "Ingredients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ingredient3",
                table: "Ingredients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ingredient4",
                table: "Ingredients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ingredient5",
                table: "Ingredients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ingredient6",
                table: "Ingredients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ingredient7",
                table: "Ingredients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ingredient8",
                table: "Ingredients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ingredient9",
                table: "Ingredients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Steps_RecipeId",
                table: "Steps",
                column: "RecipeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients",
                column: "RecipeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Steps_RecipeId",
                table: "Steps");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Step2",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "Step3",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "Step4",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "Step5",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "Ingredient10",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Ingredient2",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Ingredient3",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Ingredient4",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Ingredient5",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Ingredient6",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Ingredient7",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Ingredient8",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Ingredient9",
                table: "Ingredients");

            migrationBuilder.RenameColumn(
                name: "Step1",
                table: "Steps",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "Ingredient1",
                table: "Ingredients",
                newName: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_RecipeId",
                table: "Steps",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients",
                column: "RecipeId");
        }
    }
}
