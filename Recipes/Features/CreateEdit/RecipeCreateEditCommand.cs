using MediatR;
using Recipes.Data;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<int> SelectedIngredientIds { get; set; }
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

            var currentIngredients = _context.RecipeIngredient.Where(x => x.RecipeId == request.Id).ToList();

            deleteIngredients();
            addNewIngredients();

            await _context.SaveChangesAsync();

            void deleteIngredients()
            {             
                var deletedIngredients = currentIngredients.Where(x => request.SelectedIngredientIds.Contains(x.IngredientId) == false);

                _context.RecipeIngredient.RemoveRange(deletedIngredients);
            }

            void addNewIngredients()
            {
                var newIngredients = request.SelectedIngredientIds
                    .Where(x => currentIngredients.Select(x => x.IngredientId).Contains(x) == false)
                    .Select(x => new RecipeIngredient
                    {
                        Recipe = recipe,
                        IngredientId = x,
                    });

                _context.RecipeIngredient.AddRangeAsync(newIngredients);
            }

            return recipe.Id;
        }
    }
}
