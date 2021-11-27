using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
            var recipes = _context.Recipe
                .Include(x => x.Ingredients)
                .ThenInclude(x => x.Ingredient)
                .Include(x => x.Instructions)
                .Where(x => x.Id == 1)
                .ToList();


        }
    }
}
