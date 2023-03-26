using System.ComponentModel.DataAnnotations;

namespace MyRecipeBook.Models
{
    public class Step
    {
        [Key]
        public int Id { get; set; }

        [StringLength(250, MinimumLength = 3)]
        public string Step1 { get; set; } = null!;
        [StringLength(250)]
        public string? Step2 { get; set; }
        [StringLength(250)]
        public string? Step3 { get; set; }
        [StringLength(250)]
        public string? Step4 { get; set; }
        [StringLength(250)]
        public string? Step5 { get; set; } 

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; } = null!;
    }
}
