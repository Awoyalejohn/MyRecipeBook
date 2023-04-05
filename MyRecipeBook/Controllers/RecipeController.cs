using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Data;
using MyRecipeBook.Models;
using MyRecipeBook.Models.ViewModels;
using static System.Net.Mime.MediaTypeNames;
using System.Net;
using MyRecipeBook.Repositotory;
using MyRecipeBook.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace MyRecipeBook.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IImageService _imageService;
        private readonly MyRecipeBookContext _context;
        public RecipeController(IRecipeRepository recipeRepository, IImageService imageService, MyRecipeBookContext context)
        {
            _recipeRepository = recipeRepository;
            _imageService = imageService;
            _context = context;
        }

        // GET: Recipe
        public async Task<IActionResult> Index(string searchString,
            string category, string cuisine, int? pageNumber)
        {

            var recipes = _recipeRepository.GetRecipesQuery();

            var categoryQuery = _recipeRepository.GetRecipeCategoryQuery();

            var cuisineQuery = _recipeRepository.GetRecipeCuisineQuery();

            if (!string.IsNullOrEmpty(searchString))
            {
                recipes = recipes
                .Where(s => s.Name.Contains(searchString) ||
                s.Description.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(category))
            {
                recipes = recipes.Where(c => c.Category == category);
            }

            if (!string.IsNullOrEmpty(cuisine))
            {
                recipes = recipes.Where(c => c.Cuisine == cuisine);
            }

            int pageSize = 3;

            ViewData["category"] = category;
            ViewData["cuisine"] = cuisine;
            ViewData["searchString"] = searchString;
            
            var recipeFilterViewModel = new RecipeFilterViewModel()
            {
                Recipes = await PaginatedList<Recipe>.CreateAsync(recipes, pageNumber ?? 1, pageSize),
                Categories = new SelectList(await categoryQuery.Distinct().ToListAsync()),
                Cuisines = new SelectList(await cuisineQuery.Distinct().ToListAsync())
            };

            return View(recipeFilterViewModel);
        }

        // GET: Recipe/Create
        public IActionResult Create() => View();

        // POST: Recipe/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Recipe,Ingredients,Steps,UploadImage")] RecipeViewModel recipeViewModel)
        {
            // Uses the RecipeViewModel to create the initial data
            if (ModelState.IsValid)
            {
                // passes in the image from the recipeViewmodel
                var imageResult = await _imageService.AddImageAsync(recipeViewModel.UploadImage);

                var recipe = new Recipe();
                // maps  the recipe viewmodel to the the recipe entity
                recipeViewModel.MapToEntity(recipe, imageResult);

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

            var currentUserId = HttpContext.User
               .FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await _context.Users
                .Include(r => r.Recipes)
                .Where(u => u.Id == currentUserId)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            var hasRecipe = await _context.Recipes.AnyAsync(r => r.MyRecipeBookUserId == currentUserId && r.Id == id);

            ViewData["Bookmarked"] = false;
            if (hasRecipe)
            {
                ViewData["Bookmarked"] = true;
            }

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
        public async Task<IActionResult> Edit(int id, [Bind("Recipe,Ingredients,Steps,UploadImage")] RecipeViewModel recipeViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit recipe");
                return View(recipeViewModel);
            }

            var recipe = await _recipeRepository.GetRecipeByIdAsync(id);

            if (recipe != null)
            {
                try
                {
                    // attempts to delete the old image
                    var fileInfo = new FileInfo(recipe.Image);
                    var publicId = Path.GetFileNameWithoutExtension(fileInfo.Name);
                    await _imageService.DeleteImageAsync(publicId);
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Could not edit image");
                    return View(recipeViewModel);
                }

                // passes in the image from the recipeViewmodel
                var imageResult = await _imageService.AddImageAsync(recipeViewModel.UploadImage);

                recipeViewModel.MapToEntity(recipe, imageResult);

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
                // Attemps to delete image before deleting the club
                var fileInfo = new FileInfo(recipe.Image);
                var publicId = Path.GetFileNameWithoutExtension(fileInfo.Name);
                await _imageService.DeleteImageAsync(publicId);

                _recipeRepository.DeleteRecipe(recipe);
                await _recipeRepository.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Could not delete image");
                return RedirectToAction(nameof(Delete), new { id, saveChangesError = true });
            }
        }
    }
}
