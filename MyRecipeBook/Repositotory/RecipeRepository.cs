using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Data;
using MyRecipeBook.Models;

namespace MyRecipeBook.Repositotory
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly MyRecipeBookContext _context;
        public RecipeRepository(MyRecipeBookContext context)
        {
            _context = context;
        }

        public void DeleteRecipe(Recipe recipe)
        {
            _context.Recipes.Remove(recipe);
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync()
        {
            return await _context.Recipes
                .AsNoTracking()
                .ToListAsync();
        }

        public IQueryable<Recipe> GetRecipesQuery()
        {
            var recipes = from recipe in _context.Recipes
                          select recipe;
            return recipes;
        }

        public IQueryable<string> GetRecipeCategoryQuery() 
        {
            var categoryQuery = from recipe in _context.Recipes
                                orderby recipe.Category
                                select recipe.Category;
            return categoryQuery;
        }
        public IQueryable<string> GetRecipeCuisineQuery()
        {
            var cuisineQuery = from recipe in _context.Recipes
                               orderby recipe.Cuisine
                               select recipe.Cuisine;
            return cuisineQuery;
        }

        public async Task<Recipe?> GetRecipeByIdAsync(int id)
        {
            return await _context.Recipes
           .Include(r => r.Ingredients)
           .Include(r => r.Steps)
           .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Recipe?> GetRecipeByIdAsyncNoTracking(int id)
        {
            return await _context.Recipes
                .Include(r => r.Ingredients)
                .Include(r => r.Steps)
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public void InsertRecipe(Recipe recipe)
        {
            _context.Add(recipe);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateRecipe(Recipe recipe)
        {
            _context.Update(recipe);
        }
    }
}
