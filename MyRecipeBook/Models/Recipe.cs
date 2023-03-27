﻿using System.ComponentModel.DataAnnotations;

namespace MyRecipeBook.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Required(ErrorMessage = "Please enter a Recipe name")]
        public string Name { get; set; } = string.Empty;

        [StringLength(250, MinimumLength = 3)]
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; } = string.Empty;

        [StringLength(50, MinimumLength = 3)]
        [Required(ErrorMessage = "Please enter a category")]
        public string Category { get; set; } = string.Empty;

        [StringLength(50, MinimumLength = 3)]
        [Required(ErrorMessage = "Please enter a cuisine")]
        public string Cuisine { get; set; } = string.Empty;

        [Range(1, 10, ErrorMessage = "Please enter a number between 1 and 10")]
        public int Serves { get; set; }

        [StringLength(30, MinimumLength = 3)]
        [Required(ErrorMessage = "Please enter the prep time")]
        public string PreparationTime { get; set; } = string.Empty;

        [StringLength(30, MinimumLength = 3)]
        [Required(ErrorMessage = "Please enter the cook time")]
        public string CookTime { get; set; } = string.Empty;

        [StringLength(100, MinimumLength = 3)]
        [Required(ErrorMessage = "Please add an image")]
        public string Image { get; set; } = string.Empty;

        public Ingredient? Ingredients { get; set; } // navigation property
        public Step? Steps { get; set; } // navigation property
    }
}
