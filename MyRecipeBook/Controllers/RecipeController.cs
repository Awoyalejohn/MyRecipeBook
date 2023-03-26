using Microsoft.AspNetCore.Mvc;

namespace MyRecipeBook.Controllers
{
    public class RecipeController : Controller
    {
        public IActionResult Index() => View();
    }
}
