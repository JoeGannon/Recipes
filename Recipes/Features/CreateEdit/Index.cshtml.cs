using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recipes.Features.Search;

namespace Recipes.Features.CreateEdit
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] RawImage { get; set; }
        public int[] SelectedIngredients { get; set; } = new int[] { };
        public List<(int Id, string Name)> AllIngredients { get; set; }
        public List<(int Id, string Description)> Instructions { get; set; } = new List<(int Id, string Description)>();
        public IFormFile Image { get; set; }

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task OnGet(int? id)
        {
            if (id != null)
            {
                var result = (await _mediator.Send(new RecipeSearchQuery { Id = id })).SingleOrDefault() ?? new RecipeSearchResult();

                Id = result.Id;
                Title = result.Title;
                Description = result.Description;
                RawImage = result.Image;
                Instructions = result.Instructions.Select(x => (x.Id, x.Description)).ToList();
                SelectedIngredients = result.Ingredients.Select(x => x.Id).ToArray();
            }

            AllIngredients = (await _mediator.Send(new AllIngredientsQuery())).Select(x => (x.Id, x.Name)).ToList();
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
                SelectedIngredientIds = SelectedIngredients
            };

            var id = await _mediator.Send(recipeCreate);

            return RedirectToPage(new { id = id });
        }

        public async Task<IActionResult> OnPostInstructionDelete(int instructionId)
        {
            await _mediator.Send(new DeleteCommand<Data.Instruction> { Id = instructionId });

            return null;
        }

        public async Task<IActionResult> OnPostInstructionAdd(int recipeId, string description)
        {
            var id = await _mediator.Send(new AddCommand<Data.Instruction> { Entity = new Data.Instruction { Description = description, RecipeId = recipeId } });

            return new JsonResult(new { Id = id, Description = description });
        }
    }
}
