using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Data;
using MyRecipeBook.Models;
using MyRecipeBook.Models.ViewModels;
using static System.Net.Mime.MediaTypeNames;
using System.Net;
using MyRecipeBook.Repositotory;

namespace MyRecipeBook.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRecipeRepository _recipeRepository;
        public RecipeController(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        // GET: Recipe
        public async Task<IActionResult> Index()
        {
            return View(await _recipeRepository.GetAllRecipesAsync());
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
                    _recipeRepository.InsertRecipe(recipe);
                    await _recipeRepository.SaveAsync();
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
            if (id == null) return NotFound();

            var recipe = await _recipeRepository
                .GetRecipeByIdAsyncNoTracking(Convert.ToInt32(id));

            if (recipe == null) { return NotFound(); }

            return View(recipe);
        }

        // GET Recipe/Edit/{Id}
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var recipe = await _recipeRepository
                .GetRecipeByIdAsyncNoTracking(Convert.ToInt32(id));

            if (recipe == null) { return NotFound(); }

            var recipeViewModel = new RecipeViewModel()
            {
                Recipe = recipe,
                Ingredients = recipe.Ingredients,
                Steps = recipe.Steps
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

            var recipe = await _recipeRepository.GetRecipeByIdAsync(id);

            if (recipe != null)
            {
                recipe.Name = recipeViewModel.Recipe.Name;
                recipe.Description = recipeViewModel.Recipe.Description;
                recipe.Category = recipeViewModel.Recipe.Category;
                recipe.Cuisine = recipeViewModel.Recipe.Cuisine;
                recipe.Serves = recipeViewModel.Recipe.Serves;
                recipe.Ingredients.Ingredient1 = recipeViewModel.Ingredients.Ingredient1;
                recipe.Ingredients.Ingredient2 = recipeViewModel.Ingredients.Ingredient2;
                recipe.Ingredients.Ingredient3 = recipeViewModel.Ingredients.Ingredient3;
                recipe.Ingredients.Ingredient4 = recipeViewModel.Ingredients.Ingredient4;
                recipe.Ingredients.Ingredient5 = recipeViewModel.Ingredients.Ingredient5;
                recipe.Ingredients.Ingredient6 = recipeViewModel.Ingredients.Ingredient6;
                recipe.Ingredients.Ingredient7 = recipeViewModel.Ingredients.Ingredient7;
                recipe.Ingredients.Ingredient8 = recipeViewModel.Ingredients.Ingredient8;
                recipe.Ingredients.Ingredient9 = recipeViewModel.Ingredients.Ingredient9;
                recipe.Ingredients.Ingredient10 = recipeViewModel.Ingredients.Ingredient10;
                recipe.Steps.Step1 = recipeViewModel.Steps.Step1;
                recipe.Steps.Step2 = recipeViewModel.Steps.Step2;
                recipe.Steps.Step3 = recipeViewModel.Steps.Step3;
                recipe.Steps.Step4 = recipeViewModel.Steps.Step4;
                recipe.Steps.Step5 = recipeViewModel.Steps.Step5;
                recipe.PreparationTime = recipeViewModel.Recipe.PreparationTime;
                recipe.CookTime = recipeViewModel.Recipe.CookTime;
                recipe.Image = recipeViewModel.Recipe.Image;

                try
                {
                    _recipeRepository.UpdateRecipe(recipe);
                    await _recipeRepository.SaveAsync();
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

        // GET: Recipe/Delete/{id}
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var recipe = await _recipeRepository
                .GetRecipeByIdAsyncNoTracking(Convert.ToInt32(id));

            if (recipe == null) { return NotFound(); }

            return View(recipe);
        }

        //POST: Recipe/Delete/{id}
        [HttpPost, ActionName(nameof(Delete))]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _recipeRepository
               .GetRecipeByIdAsync(id);

            if (recipe == null) return NotFound();

            try
            {
                _recipeRepository.DeleteRecipe(recipe);
                await _recipeRepository.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id, saveChangesError = true });
            }
        }
    }
}
