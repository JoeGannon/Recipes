using System.Collections.Generic;

namespace Recipes.Features.Search
{
    public class RecipeSearchResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
        public IEnumerable<Instruction> Instructions { get; set; }
    }

    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Instruction
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }    
}
