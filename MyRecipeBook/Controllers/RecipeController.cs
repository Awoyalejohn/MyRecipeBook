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
                    Name = recipeViewModel.Recipe.Name,
                    Description = recipeViewModel.Recipe.Description,
                    Category = recipeViewModel.Recipe.Category,
                    Cuisine = recipeViewModel.Recipe.Cuisine,
                    Serves = recipeViewModel.Recipe.Serves,
                    Ingredients = recipeViewModel.Ingredients,
                    Steps = recipeViewModel.Steps,
                    PreparationTime = recipeViewModel.Recipe.PreparationTime,
                    CookTime = recipeViewModel.Recipe.CookTime,
                    Image = recipeViewModel.Recipe.Image
                };

                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("", "Error with the form");
            }
            return View(recipeViewModel);
        }
    }
}
