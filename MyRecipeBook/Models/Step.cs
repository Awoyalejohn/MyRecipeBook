using System.ComponentModel.DataAnnotations;

namespace MyRecipeBook.Models
{
    public class Step
    {
        [Key]
        public int Id { get; set; }

        [StringLength(250, MinimumLength = 3)]
        public string Content { get; set; } = null!;

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; } = null!;
    }
}
