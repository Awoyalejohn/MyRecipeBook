using System.ComponentModel.DataAnnotations;

namespace MyRecipeBook.Models
{
    public class Method
    {
        public int Id { get; set; }

        [StringLength(250, MinimumLength = 3)]
        [Required(ErrorMessage = "Please add a step")]
        public string Step { get; set; } = string.Empty;

        public int RecipeId { get; set; } // foreign key property
        public Recipe? Recipe { get; set; } // navigation property
    }
}
