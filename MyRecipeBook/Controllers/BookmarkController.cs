using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Data;
using MyRecipeBook.Repositotory;
using System.Security.Claims;

namespace MyRecipeBook.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class BookmarkController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IRecipeRepository _recipeRepository;

        public BookmarkController(IUserRepository userRepository, IRecipeRepository recipeRepository)
        {
            _userRepository = userRepository;
            _recipeRepository = recipeRepository;
        }

        public async Task<IActionResult> Index()
        {
            var bookmarkedRecipes = await _userRepository.GetUserRecipes();

            return View(bookmarkedRecipes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBookmark(int id)
        {
            var recipe = await _recipeRepository.GetRecipeByIdAsync(id);

            if (recipe == null) { return NotFound(); }

            await _userRepository.AddRecipeToUser(recipe);

            await _userRepository.SaveAsync();
            TempData["success"] = "Recipe bookmarked successfully";
            return RedirectToAction("Detail", "Recipe", new { Id = id});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveBookmark(int id)
        {
            var recipe = await _recipeRepository.GetRecipeByIdAsync(id);

            if (recipe == null) { return NotFound(); }

            await _userRepository.RemoveRecipeFromUser(recipe);

            await _userRepository.SaveAsync();
            TempData["success"] = "Removed Recipe bookmark successfully";
            return RedirectToAction("Detail", "Recipe", new { Id = id });
        }
    }
}
