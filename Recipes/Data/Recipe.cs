using System.Collections.Generic;

namespace Recipes.Data
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set;  }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public ICollection<RecipeIngredient> Ingredients { get; set; }
        public ICollection<Instruction> Instructions { get; set; }
    }
}
