using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace MyRecipeBook.Models
{
    public class MyRecipeBookUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public ICollection<Recipe>? Recipes { get; set; } // navigation property
    }
}
