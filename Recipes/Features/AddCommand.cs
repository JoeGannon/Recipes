using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recipes.Data;

namespace Recipes.Features
{
    public class AddCommand<T> : IRequest<int> where T : Entity
    {
        public T Entity { get; set; }
    }

    public class AddCommandHandler<T> : IRequestHandler<AddCommand<T>, int> where T : Entity
    {
        private readonly RecipeContext _context;

        public AddCommandHandler(RecipeContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddCommand<T> request, CancellationToken cancellationToken)
        {
            _context.Set<T>().Add(request.Entity);

            await _context.SaveChangesAsync();

            return request.Entity.Id;
        }
    }
}
