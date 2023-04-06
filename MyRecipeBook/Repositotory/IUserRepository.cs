using MyRecipeBook.Models;

namespace MyRecipeBook.Repositotory
{
    public interface IUserRepository
    {
        string GetUserId();
        Task<MyRecipeBookUser> GetUserByIdAsync(string userId);
        Task<MyRecipeBookUser> GetUserByIdAsyncNoTracking(string userId);
        Task<IEnumerable<Recipe>> GetUserRecipes();
        Task AddRecipeToUser(Recipe recipe);
        Task RemoveRecipeFromUser(Recipe recipe);
        Task SaveAsync();
    }
}
