using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyRecipeBook.Migrations
{
    /// <inheritdoc />
    public partial class revertChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cuisine = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Serves = table.Column<int>(type: "int", nullable: false),
                    PreparationTime = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CookTime = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ingredient1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ingredient2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ingredient3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ingredient4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ingredient5 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ingredient6 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ingredient7 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ingredient8 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ingredient9 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ingredient10 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Step1 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Step2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Step3 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Step4 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Step5 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Steps_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients",
                column: "RecipeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Steps_RecipeId",
                table: "Steps",
                column: "RecipeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
