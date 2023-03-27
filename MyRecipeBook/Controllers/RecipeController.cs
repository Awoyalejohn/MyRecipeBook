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

        // GET Recipe/Edit/{Id}
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Recipes == null) 
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.FindAsync(id);

            if (recipe == null) { return NotFound(); }

            var recipeViewModel = new RecipeViewModel()
            {
               Recipe = recipe,
               Ingredients = recipe.Ingredients!,
               Steps = recipe.Steps!
            };
            // TODO: Here is a good place to pass info into the constructor

            return View(recipeViewModel);

        }

        // POST Recipe/Edit/{Id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Recipe,Ingredients,Steps")] RecipeViewModel recipeViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit recipe");
                return View(recipeViewModel);
            }

            var recipe = await _context.Recipes.FirstOrDefaultAsync(r =>r.Id == id);

            if (recipe != null)
            {
                recipe = recipeViewModel.Recipe;
                recipe.Ingredients = recipeViewModel.Ingredients;
                recipe.Steps = recipeViewModel.Steps;

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
            return View(recipeViewModel);


        }
        private bool RecipeExists(int id)
        {
            return _context.Recipes.Any(r => r.Id == id);
        }

    }
}
