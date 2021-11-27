using MediatR;
using Microsoft.EntityFrameworkCore;
using Recipes.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Recipes.Features.Search
{
    public class RecipeSearchQuery : IRequest<IEnumerable<RecipeSearchResult>>
    {
        public string Query { get; set; }
    }

    public class RecipeSearchQueryHandler : IRequestHandler<RecipeSearchQuery, IEnumerable<RecipeSearchResult>>
    {
        private readonly RecipeContext _context;

        public RecipeSearchQueryHandler(RecipeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RecipeSearchResult>> Handle(RecipeSearchQuery request, CancellationToken cancellationToken)
        {
            var results = new List<RecipeSearchResult>();

            var query = _context.Recipe
                                    .Include(x => x.Ingredients)
                                    .ThenInclude(x => x.Ingredient)
                                    .Include(x => x.Instructions)
                                    .AsQueryable();

            if (string.IsNullOrWhiteSpace(request.Query) == false)
            {
                query = query.Where(x => x.Description.Contains(request.Query) || 
                                         x.Title.Contains(request.Query) ||
                                         x.Ingredients.Select(z => z.Ingredient.Name).Contains(request.Query))
                             .AsQueryable();
            }

            results = await query.Select(x => new RecipeSearchResult
                                {
                                    Id = x.Id,
                                    Title = x.Title,
                                    Description = x.Description,
                                    Ingredients = x.Ingredients.Select(z => new Ingredient { Id = z.IngredientId, Name = z.Ingredient.Name }),
                                    Instructions = x.Instructions.Select(z => new Instruction { Id = z.Id, Description = z.Description })
                                })
                                .ToListAsync();

            return results;
        }
    }
}
