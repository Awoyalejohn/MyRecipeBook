using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Data;
using MyRecipeBook.Repositotory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext<MyRecipeBookContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllersWithViews();

// Repository service
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();

var app = builder.Build();

// Configure the HTTP request pipline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapDefaultControllerRoute();

//SeedData.Initialize(app);

app.Run();
