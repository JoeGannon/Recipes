using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recipes.Features.CreateEdit;
using Recipes.Features.Search;

namespace Recipes.Pages
{
    [BindProperties]
    public class CreateEditModel : PageModel
    {
        private readonly IMediator _mediator;

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] RawImage { get; set; }
        public IFormFile Image { get; set; }

        public CreateEditModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task OnGet(int? id)
        {
            if (id != null)
            {
                var result = (await _mediator.Send(new RecipeSearchQuery { Id = id })).SingleOrDefault();

                Id = result.Id;
                Title = result.Title;
                Description = result.Description;
                RawImage = result.Image;
            }
        }

        public async Task<IActionResult> OnPost()
        {
            byte[] bytes = null;

            if (Image != null)
            {
                using var fileStream = Image.OpenReadStream();
                var length = Image.Length;
                bytes = new byte[length];
                fileStream.Read(bytes, 0, (int)length);
            }            

            var recipeCreate = new RecipeCreateEditCommand
            {
                Id = Id,
                Title = Title,
                Description = Description,
                Image = bytes ?? RawImage,
            };

            var id = await _mediator.Send(recipeCreate);

            return RedirectToPage("/CreateEdit", new { id });
        }
    }
}