using System.Collections.Generic;

namespace Recipes.Data
{
    public class Ingredient : Entity
    {
        public string Name { get; set; }
        public ICollection<RecipeIngredient> Recipes { get;set; }
    }
}
