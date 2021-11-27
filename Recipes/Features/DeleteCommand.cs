using MediatR;
using Microsoft.EntityFrameworkCore;
using Recipes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Recipes.Features
{
    public class DeleteCommand<T> : IRequest<Unit> where T : Entity 
    {
        public int Id { get; set; }
    }

    public class DeleteCommandHandler<T> : IRequestHandler<DeleteCommand<T>, Unit> where T : Entity, new()
    {
        private readonly RecipeContext _context;

        public DeleteCommandHandler(RecipeContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCommand<T> request, CancellationToken cancellationToken)
        {
            T obj = new T() { Id = request.Id };
            
            _context.Entry(obj).State = EntityState.Deleted;

            await _context.SaveChangesAsync();

            return new Unit();
        }
    }
}
