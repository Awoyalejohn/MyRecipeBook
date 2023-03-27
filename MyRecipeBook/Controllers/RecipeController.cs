using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // GET: Recipe
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recipes.ToListAsync());
        }

        // GET: Recipe/Create
        public IActionResult Create() => View();

        // POST: Recipe/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Recipe,Ingredients,Steps")] RecipeViewModel recipeViewModel)
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

                try
                {
                    _context.Add(recipe);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    //Log the error (uncomment ex varible name and write a log.
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists " +
                        "see your system administrator.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Error with the form");
            }
            return View(recipeViewModel);
        }

        // GET Recipe/Detail/{Id}
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null || _context.Recipes == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .Include(r => r.Ingredients)
                .Include(r => r.Steps)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (recipe == null) { return NotFound(); }

            return View(recipe);
        }

    }
}
