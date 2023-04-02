using MyRecipeBook.Models;

namespace MyRecipeBook.Repositotory
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> GetAllRecipesAsync();
        IQueryable<Recipe> GetRecipesQuery();
        IQueryable<string> GetRecipeCategoryQuery();
        IQueryable<string> GetRecipeCuisineQuery();
        Task<Recipe?> GetRecipeByIdAsync(int id);
        Task<Recipe?> GetRecipeByIdAsyncNoTracking(int id);
        public void InsertRecipe(Recipe recipe);
        void DeleteRecipe(Recipe recipe);
        void UpdateRecipe(Recipe recipe);
        Task SaveAsync();
    }
}
