using System.ComponentModel.DataAnnotations;

namespace MyRecipeBook.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [StringLength(250, MinimumLength = 3)]
        public string Description { get; set; } = null!;

        [StringLength(50, MinimumLength = 3)]
        public string Category { get; set; } = null!;

        [StringLength(50, MinimumLength = 3)]
        public string Cuisine { get; set; } = null!;

        [Range(1, 10)]
        public int Serves { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; } = null!;
        public ICollection<Step> Steps { get; set; } = null!;
        public TimeSpan PreparationTime { get; set; }
        public TimeSpan CookTime { get; set; }
        public string Image { get; set; } = null!;
    }
}
