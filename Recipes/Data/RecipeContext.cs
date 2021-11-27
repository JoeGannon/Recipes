using Microsoft.EntityFrameworkCore;

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
            modelBuilder.Entity<Ingredient>().HasData(new Ingredient { Id = 3, Name = "Butter" });
            modelBuilder.Entity<Ingredient>().HasData(new Ingredient { Id = 4, Name = "Baking Soda" });
            modelBuilder.Entity<Ingredient>().HasData(new Ingredient { Id = 5, Name = "Sugar" });
            modelBuilder.Entity<Ingredient>().HasData(new Ingredient { Id = 6, Name = "Milk" });
            modelBuilder.Entity<Ingredient>().HasData(new Ingredient { Id = 7, Name = "Eggs" });
            modelBuilder.Entity<Ingredient>().HasData(new Ingredient { Id = 8, Name = "Garlic" });
            modelBuilder.Entity<Ingredient>().HasData(new Ingredient { Id = 9, Name = "Hot Sauce" });

            modelBuilder.Entity<Instruction>().HasData(new Instruction { Id = 1, Description = "Add cup of Salt", RecipeId = 1 });
            modelBuilder.Entity<Instruction>().HasData(new Instruction { Id = 2, Description = "Add cup of pepper", RecipeId = 1 });
            modelBuilder.Entity<Instruction>().HasData(new Instruction { Id = 3, Description = "Mix warm milk, yeast, 2 tsp sugar and let is sit for 10-15 mins until foamy", RecipeId = 1 });
            modelBuilder.Entity<Instruction>().HasData(new Instruction { Id = 4, Description = "Mix flour, salt, and yeast in a bowl or mixer", RecipeId = 1 });
            modelBuilder.Entity<Instruction>().HasData(new Instruction { Id = 5, Description = "Add Sugar, butter, and egg", RecipeId = 1 });
            modelBuilder.Entity<Instruction>().HasData(new Instruction { Id = 6, Description = "Mix until all ingredients are incorporated and form a smooth dough.", RecipeId = 1 });
            modelBuilder.Entity<Instruction>().HasData(new Instruction { Id = 7, Description = "Transfer to a light greased bowl and let it rise for 1 hour or until the size is doubled.", RecipeId = 1 });
            modelBuilder.Entity<Instruction>().HasData(new Instruction { Id = 8, Description = "Divide dough into 24 equal parts and shape it into a ball.", RecipeId = 1 });
            modelBuilder.Entity<Instruction>().HasData(new Instruction { Id = 9, Description = "Dip dough into the breadcrumbs and arrange in a pan.", RecipeId = 1 });
            modelBuilder.Entity<Instruction>().HasData(new Instruction { Id = 10, Description = "Let it rise for another 20 mins.", RecipeId = 1 });
            modelBuilder.Entity<Instruction>().HasData(new Instruction { Id = 11, Description = "Pre-heat oven to 350°F", RecipeId = 1 });
            modelBuilder.Entity<Instruction>().HasData(new Instruction { Id = 12, Description = "Bake for 20-25 mins or until golden brown.", RecipeId = 1 });

            modelBuilder.Entity<Instruction>().HasData(new Instruction { Id = 13, Description = "Cut the fish into 1×3 inch slices.", RecipeId = 2 });
            modelBuilder.Entity<Instruction>().HasData(new Instruction { Id = 14, Description = "In a small bowl, beat the egg for coating.", RecipeId = 2 });
            modelBuilder.Entity<Instruction>().HasData(new Instruction { Id = 16, Description = "In a separate bowl, mix flour, salt, black pepper, and paprika.", RecipeId = 2 });
            modelBuilder.Entity<Instruction>().HasData(new Instruction { Id = 17, Description = "Coat the fish in the following order: Egg, flour mix, egg again and panko then then flour.", RecipeId = 2 });
            modelBuilder.Entity<Instruction>().HasData(new Instruction { Id = 18, Description = "Heat the oil in a deep skillet over medium-high heat. Add the coated fish but don’t crowd the pan. Cook for 2 minutes or until the bottoms are golden brown. Carefully flip the pieces over with tongs, and cook another 2 minutes or until the other side is golden brown.", RecipeId = 2 });
            modelBuilder.Entity<Instruction>().HasData(new Instruction { Id = 19, Description = "Drain on paper towels.", RecipeId = 2 });
            modelBuilder.Entity<Instruction>().HasData(new Instruction { Id = 20, Description = "Top it off with Kewpie mayo, Okonomi Sauce and Bonito flakes.", RecipeId = 2 });
            modelBuilder.Entity<Instruction>().HasData(new Instruction { Id = 21, Description = "Serve and Enjoy!", RecipeId = 2 });

            modelBuilder.Entity<RecipeIngredient>().HasData(new RecipeIngredient { Id = 1, RecipeId = 1, IngredientId =1 });
            modelBuilder.Entity<RecipeIngredient>().HasData(new RecipeIngredient { Id = 2, RecipeId = 1, IngredientId = 2 });
            modelBuilder.Entity<RecipeIngredient>().HasData(new RecipeIngredient { Id = 3, RecipeId = 2, IngredientId = 1 });
        }
    }
}
