using System.ComponentModel.DataAnnotations;

namespace MyRecipeBook.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; } = null!;
    }
}
