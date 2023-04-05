using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Data;
using System.Security.Claims;

namespace MyRecipeBook.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class BookmarkController : Controller
    {
        private readonly MyRecipeBookContext _context;

        public BookmarkController(MyRecipeBookContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var currentUserId = HttpContext.User
                .FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await _context.Users.Include(r => r.Recipes).Where(u => u.Id == currentUserId).AsNoTracking().FirstOrDefaultAsync();
            var bookmarkedRecipes = user.Recipes.ToList();

            return View(bookmarkedRecipes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBookmark(int id)
        {
            var recipe = _context.Recipes.FirstOrDefault(r => r.Id == id);

            var currentUserId = HttpContext.User
                .FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await _context.Users.Include(r => r.Recipes).Where(u => u.Id == currentUserId).FirstOrDefaultAsync();

            user.Recipes.Add(recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction("Detail", "Recipe", new { Id = id});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveBookmark(int id)
        {
            var recipe = _context.Recipes.FirstOrDefault(r => r.Id == id);

            var currentUserId = HttpContext.User
                .FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await _context.Users.Include(r => r.Recipes).Where(u => u.Id == currentUserId).FirstOrDefaultAsync();

            user.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction("Detail", "Recipe", new { Id = id });
        }


    }
}
