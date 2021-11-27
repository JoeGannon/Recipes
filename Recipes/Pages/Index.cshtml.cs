using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Recipes.Data;

namespace Recipes.Pages
{
    public class IndexModel : PageModel
    {
        private readonly RecipeContext _context;

        public IndexModel(RecipeContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public IActionResult OnGetSearch(string query)
        {
            var recipes = new List<RecipeViewModel>();

            if (string.IsNullOrWhiteSpace(query))
            {
                recipes = _context.Recipe
                                    .Include(x => x.Ingredients)
                                    .ThenInclude(x => x.Ingredient)
                                    .Include(x => x.Instructions)
                                    .Select(x => new RecipeViewModel
                                    {
                                        Id = x.Id,
                                        Title = x.Title,
                                        Description = x.Description,
                                        Ingredients = x.Ingredients.Select(z => new IngredientViewModel { Id = z.IngredientId, Name = z.Ingredient.Name }),
                                        Instructions = x.Instructions.Select(z => new InstructionViewModel { Id = z.Id, Description = z.Description })
                                    })
                                    .ToList();
            }
            else
            {
                recipes = _context.Recipe
                                   .Include(x => x.Ingredients)
                                   .ThenInclude(x => x.Ingredient)
                                   .Include(x => x.Instructions)
                                   .Where(x => x.Description.Contains(query) || x.Title.Contains(query) || x.Ingredients.Select(z => z.Ingredient.Name).Contains(query))
                                   .Select(x => new RecipeViewModel
                                   {
                                       Id = x.Id,
                                       Title = x.Title,
                                       Description = x.Description,
                                       Ingredients = x.Ingredients.Select(z => new IngredientViewModel { Id = z.IngredientId, Name = z.Ingredient.Name }),
                                       Instructions = x.Instructions.Select(z => new InstructionViewModel { Id = z.Id, Description = z.Description })
                                   })                                   
                                   .ToList();
            }


            return new JsonResult(new { Recipes = recipes });
        }
    }

    public class RecipeViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<IngredientViewModel> Ingredients { get; set; }
        public IEnumerable<InstructionViewModel> Instructions { get; set; }
    }

    public class IngredientViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class InstructionViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
