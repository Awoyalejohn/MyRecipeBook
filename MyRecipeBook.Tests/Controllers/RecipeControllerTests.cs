using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MyRecipeBook.Controllers;
using MyRecipeBook.Models;
using MyRecipeBook.Models.ViewModels;
using MyRecipeBook.Repositotory;
using MyRecipeBook.Services;
using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Tests.Controllers
{
   
    public class RecipeControllerTests
    {
        private static IFormFile CreateMockImageFile(string fileName, byte[] content)
        {
            var ms = new MemoryStream(content);
            return new FormFile(ms, 0, content.Length, fileName, fileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/jpeg" // or "image/png", "image/gif", etc.
            };
        }

        [Fact]
        public async Task Index_ReturnsAListOfRecipes()
        {
            // Arrange
            var mockRecipeRepository = new Mock<IRecipeRepository>();
            var mockImageService = new Mock<IImageService>();
            var testData = new List<Recipe>() 
            {
                new Recipe()
            {
                Id = 1,
                Name = "Crusted Pork",
                Description = "An easy herb crusted p",
                Category = "Pork",
                Cuisine = "Australian",
                Serves = 4,
                Ingredients = new Ingredient(),
                Steps = new Step(),
                PreparationTime = "2 mins",
                CookTime = "2 mins",
                Image = "food-image"

            },
                new Recipe()
            {
                Id = 2,
                Name = "Veggie Medley",
                Description = "An easy herb crusted p",
                Category = "Pork",
                Cuisine = "Australian",
                Serves = 4,
                Ingredients = new Ingredient(),
                Steps = new Step(),
                PreparationTime = "2 mins",
                CookTime = "2 mins",
                Image = "food-image"
            }
            };
            mockRecipeRepository.Setup(repo => repo.GetAllRecipesAsync())
                .ReturnsAsync(testData);
            var controller = new RecipeController(mockRecipeRepository.Object, mockImageService.Object);

            // Act
            var result = await controller.Index();

            // Assert 
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Recipe>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void Create_ReturnsAnActionResult()
        {
            // Arrange
            var mockRecipeRepository = new Mock<IRecipeRepository>();
            var mockImageService = new Mock<IImageService>();
            var controller = new RecipeController(mockRecipeRepository.Object, mockImageService.Object);
            

            // Act
            var result = controller.Create();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Create_RedirectsToIndex()
        {
            // Arrange
            var mockRecipeRepository = new Mock<IRecipeRepository>();
            var mockImageService = new Mock<IImageService>();
            var controller = new RecipeController(mockRecipeRepository.Object, mockImageService.Object);
            var imageContent = File.ReadAllBytes("test.png"); // or test.jpg, test.gif, etc.
            var mockImage = CreateMockImageFile("test.png", imageContent);
            var recipeViewModel = new RecipeViewModel()
            {
                Recipe = new Recipe() 
                {
                    Id = 1,
                    Name = "Crusted Pork",
                    Description = "An easy herb crusted p",
                    Category = "Pork",
                    Cuisine = "Australian",
                    Serves = 4,
                    Ingredients = new Ingredient(),
                    Steps = new Step(),
                    PreparationTime = "2 mins",
                    CookTime = "2 mins",
                    Image = "food-image"
                },
                Ingredients = new Ingredient()
                {
                    Id = 1,
                    Ingredient1 = "potato"
                },
                Steps = new Step()
                {
                    Id = 1,
                    Step1 = "do something"
                },
                UploadImage = mockImage
            };

            // Act
            var result = await controller.Create(recipeViewModel);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockImageService.Verify(x => x.AddImageAsync(recipeViewModel.UploadImage), Times.Once());
        }

    }
}
