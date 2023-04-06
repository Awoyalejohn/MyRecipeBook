using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Data;
using MyRecipeBook.Models;
using System.Security.Claims;

namespace MyRecipeBook.Repositotory
{
    public class UserRepository : IUserRepository
    {
        private readonly MyRecipeBookContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRepository(MyRecipeBookContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddRecipeToUser(Recipe recipe)
        {
            string userId = GetUserId();
            MyRecipeBookUser user = await GetUserByIdAsync(userId);
            user.Recipes.Add(recipe);
        }

        public async Task<MyRecipeBookUser> GetUserByIdAsync(string userId)
        {
            var recipeBookUser = await _context.Users
                .Include(u => u.Recipes)
                .FirstOrDefaultAsync(u => u.Id == userId);

            return recipeBookUser;
        }

        public async Task<MyRecipeBookUser> GetUserByIdAsyncNoTracking(string userId)
        {
            var recipeBookUser = await _context.Users
               .Include(u => u.Recipes)
               .AsNoTracking()
               .FirstOrDefaultAsync(u => u.Id == userId);

            return recipeBookUser;
        }

        public string GetUserId()
        {
            string userId =  _httpContextAccessor.HttpContext.User
                .FindFirstValue(ClaimTypes.NameIdentifier);

            return userId;
        }

        public async Task<IEnumerable<Recipe>> GetUserRecipes()
        {
            string userId = GetUserId();
            MyRecipeBookUser user = await GetUserByIdAsyncNoTracking(userId);
            return user.Recipes.ToList();
        }

        public async Task RemoveRecipeFromUser(Recipe recipe)
        {
            string userId = GetUserId();
            MyRecipeBookUser user = await GetUserByIdAsync(userId);
            user.Recipes.Remove(recipe);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
