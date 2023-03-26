/*using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Models;

namespace MyRecipeBook.Data
{
    public static class SeedData
    {
        public static void Initialize(IApplicationBuilder applicationBuilder)
        {
            using var scope = applicationBuilder.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<MyRecipeBookContext>();

            context.Database.EnsureCreated();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Recipes.Any())
            {
                context.Recipes.AddRange(
                    new Recipe
                    {
                        Id = 1,
                        Name = "Herb Crusted Pork Cutlets with Veggie Medley",
                        Description = "An easy herb crusted pork cutlet recipe idea made in one pan." +
                            "Made with mixed vegetables to serve with these " +
                            "crispy pork cutlets are all cooked in one easy tray bake recipe.",
                        Category = "Pork",
                        Cuisine = "Australian",
                        Serves = 4,
                        Ingredients = new List<Ingredient>
                        {
                                new Ingredient { Id = 1, Name = "40 g (¼ cup) plain flour", RecipeId = 1, Recipe = },
                                new Ingredient { Name = "4 pork cutlets, trimmed and battered out to 1 cm thickness" },
                                new Ingredient { Name = "2 eggs, beaten" },
                                new Ingredient { Name = "3 cups panko breadcrumbs" }
                        },
                        Steps = new List<Step>
                        {
                                new Step
                                {
                                    Content = "Place the flour in a large shallow bowl. " +
                                    "Season with salt and pepper. Place the beaten egg in another " +
                                    "shallow bowl and the panko crumbs with rosemary in a third shallow bowl"
                                },
                                new Step
                                {
                                    Content = "Press the cutlets in the seasoned flour, dip in the egg wash " +
                                    "and press into the rosemary crumbs to completely coat. Transfer coated " +
                                    "cutlets to a plate or small tray lined with baking paper. Place in the fridge " +
                                    "for 10-15 minutes, if time permits (this helps the crumb to stick to the cutlets while cooking)."
                                },
                                new Step
                                {
                                    Content = "Preheat the oven to 180°C/200°C fan forced. Heat the Spreadable and " +
                                    "oil in a large ovenproof frying pan or flameproof baking tray over medium to high heat. " +
                                    "Add the cutlets and shallow-fry for 2 minutes each side or until golden brown. " +
                                    "Transfer to a plate lined with paper towel and keep warm"
                                }
                        },
                        PreparationTime = TimeSpan.FromMinutes(20),
                        CookTime = TimeSpan.FromMinutes(15),
                        Image = "https://myfoodbook.com.au/sites/default/files/styles/sr_wd/public/recipe_photo/WS_Winter_Schnitzel_001.jpg"
                    },
                    new Recipe
                    {
                        Id = 2,
                        Name = "Chicken Chow Mein",
                        Description = "Learn to make this chicken chow mein recipe at home and you'll never order it takeaway again. " +
                        "Full of chow mein sauce, chicken, cabbage, stir-fried noodles and more, this satisfying meal is so easy to make.",
                        Category = "Stir Fry",
                        Cuisine = "Chinese",
                        Serves = 4,
                        Ingredients = new List<Ingredient>
                        {
                                new Ingredient { Name = "3 tbsp Rosella Organic Sweet Chilli Sauce" },
                                new Ingredient { Name = "2 tbsp light soy sauce" },
                                new Ingredient { Name = "2 tbsp oyster sauce" },
                                new Ingredient { Name = "1 tsp sesame oil" }
                        },
                        Steps = new List<Step>
                        {
                                new Step
                                {
                                    Content = "Combine sweet chilli sauce, soy sauce, oyster sauce and sesame oil in a bowl. " +
                                    "Stir in white pepper and cornflour and mix well"
                                },
                                new Step
                                {
                                    Content = "Spoon 2 tbsp of the sauce into the chicken and toss to coat"
                                },
                                new Step
                                {
                                    Content = "Heat oil in a large wok over high heat. Add garlic and cook for 10 seconds. " +
                                    "Add chicken and stir-fry for 2-3 minutes or until golden and seared"
                                },
                                 new Step
                                {
                                    Content = "Add pak choy, cabbage, carrot and the green onions. Stir fry until vegetables have just wilted"
                                },
                                  new Step
                                {
                                    Content = "Toss through noodles, sauce and water. Stir fry for 1 minute"
                                },
                                    new Step
                                {
                                    Content = "Add bean sprouts and stir fry until mixed through. Remove from heat and serve immediately " +
                                    "with extra sweet chilli sauce and extra green onions"
                                }
                        },
                        PreparationTime = TimeSpan.FromMinutes(15),
                        CookTime = TimeSpan.FromMinutes(10),
                        Image = "https://myfoodbook.com.au/sites/default/files/styles/sr_wd/public/recipe_photo/Chicken_Chow_Mein_0.jpg"
                    }

                    );
            }
        }
    }
}
*/