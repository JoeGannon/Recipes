using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Recipes.Data
{
    public class RecipeContext : DbContext 
    {
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<Instruction> Instruction { get; set; }

        public RecipeContext(DbContextOptions<RecipeContext> options) : base(options)
        {
        }
    }

    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set;  }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public IEnumerable<RecipeIngredient> RecipeIngredients { get; set; }
        public IEnumerable<Instruction> Instructions { get; set; }
    }
    
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class RecipeIngredient
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }
    }

    public class Instruction
    {
        public int Id { get; set; }
        public string Name { get; set; } 
    }
}
