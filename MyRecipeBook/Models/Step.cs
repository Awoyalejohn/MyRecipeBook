using System.ComponentModel.DataAnnotations;

namespace MyRecipeBook.Models
{
    public class Step
    {
        public int Id { get; set; }

        [StringLength(250, MinimumLength = 3)]
        [Required(ErrorMessage = "Please add a step")]
        public string Step1 { get; set; } = string.Empty;

        [StringLength(250)]
        public string? Step2 { get; set; }

        [StringLength(250)]
        public string? Step3 { get; set; }

        [StringLength(250)]
        public string? Step4 { get; set; }

        [StringLength(250)]
        public string? Step5 { get; set; }

        public int RecipeId { get; set; } // foreign key property
        public Recipe? Recipe { get; set; } // navigation property
    }
}
