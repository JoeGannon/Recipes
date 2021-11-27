using System.Collections.Generic;

namespace Recipes.Data
{
    public class Recipe : Entity 
    {
        public string Title { get; set;  }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public ICollection<RecipeIngredient> Ingredients { get; set; }
        public ICollection<Instruction> Instructions { get; set; }
    }
}
