#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;

public class Recipe
{
    [Key]
    public int RecipeId {get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "Insert a name of atleast characters.")]
    public string ChefName {get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "Insert name of dish")]
    public string DishName {get; set;}

    [Required]
    [Range(1,10000, ErrorMessage ="Please insert calories")]
    public int Calories {get; set; }

    [Required]
    [Range(1, 5, ErrorMessage ="Please put how tasty from 1 to 5")]
    public int Tasty {get; set;}

    [MinLength(20, ErrorMessage ="Please leave a brief description")]
    public string Description {get; set; }


    public DateTime CreateAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt{ get; set; } = DateTime.Now;
}