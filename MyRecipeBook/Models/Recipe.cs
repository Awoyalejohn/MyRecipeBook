using System.ComponentModel.DataAnnotations;

namespace MyRecipeBook.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string Cuisine { get; set; } = null!;
        public int Serves { get; set; }
        public List<string> Ingredients { get; set; } = null!;
        public List<string> Steps { get; set; } = null!;
        public DateTime PreparationTime { get; set; }
        public DateTime CookTime { get; set; }
    }
}
