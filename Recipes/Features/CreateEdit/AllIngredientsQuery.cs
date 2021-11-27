using MediatR;
using Microsoft.EntityFrameworkCore;
using Recipes.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Recipes.Features.CreateEdit
{
    public class AllIngredientsQuery : IRequest<IEnumerable<Ingredient>>
    {
    }

    public class AllIngredientsQueryHandler : IRequestHandler<AllIngredientsQuery, IEnumerable<Ingredient>>
    {
        private readonly RecipeContext _context;

        public AllIngredientsQueryHandler(RecipeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ingredient>> Handle(AllIngredientsQuery request, CancellationToken cancellationToken)
        {
            var ingredients = await _context.Ingredient.ToListAsync();

            return ingredients;
        }
    }
}
