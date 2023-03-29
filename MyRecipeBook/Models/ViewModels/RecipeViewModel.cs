using System.ComponentModel.DataAnnotations;

namespace MyRecipeBook.Models.ViewModels
{
    public class RecipeViewModel
    {
        public Recipe Recipe { get; set; } = null!;
        public Ingredient Ingredients { get; set; } = null!; 
        public Step Steps { get; set; } = null!;
        [Required(ErrorMessage = "Please add an image")]
        public IFormFile UploadImage { get; set; } = null!;
    }
}
