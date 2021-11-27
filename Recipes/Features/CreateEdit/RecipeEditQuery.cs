using MediatR;

namespace Recipes.Features.CreateEdit
{
    public class RecipeEditQuery : IRequest<Unit>
    {
        public int Id { get; set; }
    }

    public class RecipeEditQueryHandler 
    {

    }
}
