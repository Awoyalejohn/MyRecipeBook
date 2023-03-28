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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.Ingredients)
                .WithOne(i => i.Recipe)
                .HasForeignKey<Ingredient>(i => i.RecipeId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Ingredient>()
                .HasOne(i => i.Recipe)
                .WithOne(r => r.Ingredients)
                .IsRequired(false);

            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.Steps)
                .WithOne(s => s.Recipe)
                .HasForeignKey<Step>(s => s.RecipeId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Step>()
                .HasOne(s => s.Recipe)
                .WithOne(r => r.Steps)
                .IsRequired(false);
        }
    }
}
