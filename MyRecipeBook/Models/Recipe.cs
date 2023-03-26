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
        public Ingredient Ingredients { get; set; } = null!;
        public Step Steps { get; set; } = null!;
        public string PreparationTime { get; set; } = string.Empty;
        public string CookTime { get; set; } = string.Empty;
        public string Image { get; set; } = null!;
    }
}
