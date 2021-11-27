using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recipes.Features.Search;

namespace Recipes.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnGetSearch(string query)
        {
            var recipes = await _mediator.Send(new RecipeSearchQuery { Query = query });            

            return new JsonResult(new { Recipes = recipes });
        }
    }
}
