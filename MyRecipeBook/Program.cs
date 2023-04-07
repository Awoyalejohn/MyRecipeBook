using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Data;
using MyRecipeBook.Helpers;
using MyRecipeBook.Models;
using MyRecipeBook.Repositotory;
using MyRecipeBook.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext<MyRecipeBookContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Set up Identity service
builder.Services.AddDefaultIdentity<MyRecipeBookUser>(options =>
options.SignIn.RequireConfirmedAccount = false)
    .AddDefaultTokenProviders()
    .AddRoles<IdentityRole>() // <--------
    .AddEntityFrameworkStores<MyRecipeBookContext>();

builder.Services.AddControllersWithViews();

// Repository service
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Add services for Cloudianry
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    await SeedData.SeedRolesAsync(services);
}

// Configure the HTTP request pipline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapDefaultControllerRoute();

app.MapRazorPages();

app.Run();
