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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>().HasData(new Recipe { Id = 1, Title = "Recipe 1", Description = "The Best Recipe" });
            modelBuilder.Entity<Recipe>().HasData(new Recipe { Id = 2, Title = "Recipe 2", Description = "Not Quite The Best Recipe" });

            modelBuilder.Entity<Ingredient>().HasData(new Ingredient { Id = 1, Name = "Salt" });
            modelBuilder.Entity<Ingredient>().HasData(new Ingredient { Id = 2, Name = "Pepper" });

            modelBuilder.Entity<Instruction>().HasData(new Instruction { Id = 1, Description = "Add cup of Salt", RecipeId = 1 });
            modelBuilder.Entity<Instruction>().HasData(new Instruction { Id = 2, Description = "Add cup of pepper", RecipeId = 1 });

            modelBuilder.Entity<RecipeIngredient>().HasData(new RecipeIngredient { Id = 1, RecipeId = 1, IngredientId =1 });
            modelBuilder.Entity<RecipeIngredient>().HasData(new RecipeIngredient { Id = 2, RecipeId = 1, IngredientId = 2 });
            modelBuilder.Entity<RecipeIngredient>().HasData(new RecipeIngredient { Id = 3, RecipeId = 2, IngredientId = 1 });
        }
    }

    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set;  }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public ICollection<RecipeIngredient> Ingredients { get; set; }
        public ICollection<Instruction> Instructions { get; set; }
    }

    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RecipeIngredient> Recipes { get;set; }
    }

    public class RecipeIngredient
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }

    public class Instruction
    {
        public int Id { get; set; }
        public string Description { get; set; } 
        public int RecipeId { get; set; }
    }
}
