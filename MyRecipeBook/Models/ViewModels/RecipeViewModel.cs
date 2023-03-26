using System.ComponentModel.DataAnnotations;

namespace MyRecipeBook.Models.ViewModels
{
    public class RecipeViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter a name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Enter a description")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Enter a category")]
        public string? Category { get; set; }
        [Required(ErrorMessage = "Enter a Cuisine")]
        public string? Cuisine { get; set; }
        public int Serves { get; set; }
        public Ingredient Ingredients { get; set; } = null!;
        public Step Steps { get; set; } = null!;
        [Required(ErrorMessage = "Add the prep time")]
        public string? PreparationTime { get; set; }
        [Required(ErrorMessage = "Add the cook time")]
        public string? CookTime { get; set; }
        [Required(ErrorMessage = "Add an image")]
        public string? Image { get; set; }
    }
}
