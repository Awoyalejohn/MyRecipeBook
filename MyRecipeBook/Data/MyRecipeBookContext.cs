using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Models;

namespace MyRecipeBook.Data
{
    public class MyRecipeBookContext : DbContext
    {
        public MyRecipeBookContext(DbContextOptions<MyRecipeBookContext> options) : base(options) { }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Step> Steps { get; set; }
    }
}
