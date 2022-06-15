using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;


public class RecipesController : Controller
{
    private ORMContext _context;

    public RecipesController(ORMContext context)
    {
        _context = context;
    }

    [HttpGet("/recipes/new")]
    public IActionResult New()
    {
        return View("New");
    }

    [HttpPost("/recipes/create")]
    public IActionResult Create(Recipe newRecipe)
    {
        if (ModelState.IsValid == false)
        {
            // if we don't validate, we'll send the user back to the create new post page
            return New();
        }

        //only runs if ModelState  *IS*  valid
        _context.Recipes.Add(newRecipe);
        // _context doesn't update until we run SaveChanges
        // after SaveChanges, then our newPost will have a PostId
        _context.SaveChanges();

        return RedirectToAction("All");
    }

    [HttpGet("/recipes/all")]
    public IActionResult All()
    {
        List<Recipe> allRecipes = _context.Recipes.ToList();

        return View("All", allRecipes);
    }

    [HttpGet("/recipes/{recipeId}")]
    public IActionResult Details(int recipeId)
    {
        Recipe? foundRecipe = _context.Recipes.FirstOrDefault(recipe => recipe.RecipeId == recipeId);
        if (foundRecipe != null)
        {
            return View("Details", foundRecipe);
        }
        return RedirectToAction("All");
    }

    [HttpGet("recipes/{recipeId}/edit")]
    public IActionResult Edit(int recipeId)
    {
        Recipe? foundRecipe = _context.Recipes.FirstOrDefault(recipe => recipe.RecipeId == recipeId);
        if(foundRecipe != null)
        {
            return View("Edit", foundRecipe);
        }
        return RedirectToAction("All");
    }
    [HttpPost("/recipes/{recipeId}/update")]
    public IActionResult Update(Recipe updatedRecipe, int recipeId)
    {
        if (ModelState.IsValid)
        {
            Recipe? recipe = _context.Recipes.FirstOrDefault(recipe => recipe.RecipeId == recipeId);
            if(recipe !=null)
            {
                recipe.DishName = updatedRecipe.DishName;
                recipe.ChefName = updatedRecipe.ChefName;
                recipe.Calories = updatedRecipe.Calories;
                recipe.Tasty = updatedRecipe.Tasty;
                recipe.Description = updatedRecipe.Description;
                recipe.UpdatedAt = DateTime.Now;

                _context.Recipes.Update(recipe);
                _context.SaveChanges();
            }
            return RedirectToAction("Details", recipeId);
        }
        else{
            return Edit(recipeId);
        }   
    }
    [HttpPost("recipes/{recipeId}/delete")]
    public IActionResult Delete(int recipeId)
    {
        Recipe? recipe = _context.Recipes.FirstOrDefault(recipe => recipe.RecipeId == recipeId);
        if (recipe != null)
        {
            _context.Recipes.Remove(recipe);
            _context.SaveChanges();
        }
        return RedirectToAction("All");
    }
}