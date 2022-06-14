using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers;

public class HomeController : Controller
{
    private MyContext _context;

    public HomeController(MyContext context)
    {
        _context = context;
    }
    [HttpGet("")]
    public IActionResult Index()
    {
        List<Recipe> AllRecipes = _context.Recipes.ToList();

        return View();
    }
}
