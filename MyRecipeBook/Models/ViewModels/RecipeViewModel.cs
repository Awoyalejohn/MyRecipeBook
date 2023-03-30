using CloudinaryDotNet.Actions;
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

    public static class RecipeExtensions
    {
        public static void MapToEntity(this RecipeViewModel viewModel,
            Recipe entity, ImageUploadResult imageResult)
        {
            entity.Name = viewModel.Recipe.Name;
            entity.Description = viewModel.Recipe.Description;
            entity.Category = viewModel.Recipe.Category;
            entity.Cuisine = viewModel.Recipe.Cuisine;
            entity.Serves = viewModel.Recipe.Serves;
            entity.Ingredients ??= new Ingredient();
            entity.Ingredients.Ingredient1 = viewModel.Ingredients.Ingredient1;
            entity.Ingredients.Ingredient2 = viewModel.Ingredients.Ingredient2;
            entity.Ingredients.Ingredient3 = viewModel.Ingredients.Ingredient3;
            entity.Ingredients.Ingredient4 = viewModel.Ingredients.Ingredient4;
            entity.Ingredients.Ingredient5 = viewModel.Ingredients.Ingredient5;
            entity.Ingredients.Ingredient6 = viewModel.Ingredients.Ingredient6;
            entity.Ingredients.Ingredient7 = viewModel.Ingredients.Ingredient7;
            entity.Ingredients.Ingredient8 = viewModel.Ingredients.Ingredient8;
            entity.Ingredients.Ingredient9 = viewModel.Ingredients.Ingredient9;
            entity.Ingredients.Ingredient10 = viewModel.Ingredients.Ingredient10;
            entity.Steps ??= new Step();
            entity.Steps.Step1 = viewModel.Steps.Step1;
            entity.Steps.Step2 = viewModel.Steps.Step2;
            entity.Steps.Step3 = viewModel.Steps.Step3;
            entity.Steps.Step4 = viewModel.Steps.Step4;
            entity.Steps.Step5 = viewModel.Steps.Step5;
            entity.PreparationTime = viewModel.Recipe.PreparationTime;
            entity.CookTime = viewModel.Recipe.CookTime;
            entity.Image = imageResult.Url.ToString();
        }
    }
}
