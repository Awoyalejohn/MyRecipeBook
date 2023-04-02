using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyRecipeBook.Models.ViewModels
{
    public class RecipeFilterViewModel
    {
        public List<Recipe> Recipes { get; set; } = null!;
        public SelectList Categories { get; set; } = null!;
        public SelectList Cuisines { get; set; } = null!;
        public string? SearchString { get; set; }
        public string? Category { get; set; }
        public string? Cuisine { get; set; }

    }
}
