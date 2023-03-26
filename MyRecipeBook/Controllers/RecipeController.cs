using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Data;
using MyRecipeBook.Models;
using MyRecipeBook.Models.ViewModels;

namespace MyRecipeBook.Controllers
{
    public class RecipeController : Controller
    {
        private readonly MyRecipeBookContext _context;
        public RecipeController(MyRecipeBookContext context)
        {
            _context = context;
        }

        public IActionResult Index() => View();

        // GET: Recipe/Create
        public IActionResult Create() => View();

        // POST: Recipe/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RecipeViewModel recipeViewModel)
        {
            // Uses the RecipeViewModel to create the initial data

            

            if (ModelState.IsValid)
            {
                // passes in the data from RecipeViewModel to create the actual Recipe
                Recipe recipe = new Recipe()
                {
                    Name = recipeViewModel.Name,
                    Description = recipeViewModel.Description,
                    Category = recipeViewModel.Category,
                    Cuisine = recipeViewModel.Cuisine,
                    Serves = recipeViewModel.Serves,
                    Ingredients = new Ingredient
                    {
                        Ingredient1 = recipeViewModel.Ingredients.Ingredient1,
                        Ingredient2 = recipeViewModel.Ingredients.Ingredient2,
                        Ingredient3 = recipeViewModel.Ingredients.Ingredient3,
                        Ingredient4 = recipeViewModel.Ingredients.Ingredient4,
                        Ingredient5 = recipeViewModel.Ingredients.Ingredient5,
                        Ingredient6 = recipeViewModel.Ingredients.Ingredient6,
                        Ingredient7 = recipeViewModel.Ingredients.Ingredient7,
                        Ingredient8 = recipeViewModel.Ingredients.Ingredient8,
                        Ingredient9 = recipeViewModel.Ingredients.Ingredient9,
                        Ingredient10 = recipeViewModel.Ingredients.Ingredient10,
                    },
                    Steps = new Step()
                    {
                        Step1 = recipeViewModel.Steps.Step1,
                        Step2 = recipeViewModel.Steps.Step2,
                        Step3 = recipeViewModel.Steps.Step3,
                        Step4 = recipeViewModel.Steps.Step4,
                        Step5 = recipeViewModel.Steps.Step5,
                    },
                    PreparationTime = recipeViewModel.PreparationTime,
                    CookTime = recipeViewModel.CookTime,
                    Image = recipeViewModel.Image
                };
                
                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recipeViewModel);
        }
    }
}
