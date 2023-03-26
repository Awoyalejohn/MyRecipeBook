using System.ComponentModel.DataAnnotations;

namespace MyRecipeBook.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Ingredient1 { get; set; } = null!;
        [StringLength(50)]
        public string? Ingredient2 { get; set; }
        [StringLength(50)]
        public string? Ingredient3 { get; set; }
        [StringLength(50)]
        public string? Ingredient4 { get; set; }
        [StringLength(50)]
        public string? Ingredient5 { get; set; }
        [StringLength(50)]
        public string? Ingredient6 { get; set; }
        [StringLength(50)]
        public string? Ingredient7 { get; set; }
        [StringLength(50)]
        public string? Ingredient8 { get; set; }
        [StringLength(50)]
        public string? Ingredient9 { get; set; }
        [StringLength(50)]
        public string? Ingredient10 { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; } = null!;
    }
}
