using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Models;
using System.Diagnostics;

namespace MyRecipeBook.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Privacy() => View();

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
