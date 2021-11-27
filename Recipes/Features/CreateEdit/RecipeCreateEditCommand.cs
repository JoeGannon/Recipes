using MediatR;
using Recipes.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Recipes.Features.CreateEdit
{
    public class RecipeCreateEditCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
        public IEnumerable<Instruction> Instructions { get; set; }
    }


    public class RecipeCreateEditCommandHandler : IRequestHandler<RecipeCreateEditCommand, int>
    {
        private readonly RecipeContext _context;

        public RecipeCreateEditCommandHandler(RecipeContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(RecipeCreateEditCommand request, CancellationToken cancellationToken)
        {
            var recipe = new Recipe
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description,
                Image = request.Image
            };

            _context.Update(recipe);

            await _context.SaveChangesAsync();

            return recipe.Id;
        }
    }
}
