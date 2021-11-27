using System.Collections.Generic;

namespace Recipes.Data
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RecipeIngredient> Recipes { get;set; }
    }
}
