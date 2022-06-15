#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace CRUDelicious.Models;

public class ORMContext : DbContext
{
    public ORMContext(DbContextOptions options) : base(options){  }

    public DbSet<Recipe> Recipes {get;  set; }
}