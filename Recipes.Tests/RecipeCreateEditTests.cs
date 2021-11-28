namespace Recipes.Tests
{
    using Microsoft.EntityFrameworkCore;
    using Recipes.Features.CreateEdit;
    using Recipes.Features.Search;
    using Shouldly;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using static TestHelper;

    public class RecipeCreateEditTests
    {
        public async Task Should_Query_All_Ingredients(IEnumerable<Data.Ingredient> ingredients)
        {
            await Insert(ingredients);

            var results = await Send(new AllIngredientsQuery());

            results.ShouldNotBeNull();
            results.Count().ShouldBe(3);
        }

        public async Task Should_Create_Recipe(RecipeCreateEditCommand command, IEnumerable<Data.Ingredient> ingredients)
        {
            await Insert(ingredients);
            command.SelectedIngredientIds = ingredients.Select(x => x.Id);

            var recipeId = await Send(command);

            var results = await Send(new RecipeSearchQuery { Id = recipeId });

            var result = results.SingleOrDefault();

            result.Id.ShouldBeGreaterThan(0);
            result.Title.ShouldBe(command.Title);
            result.Description.ShouldBe(command.Description);
            result.Image.ShouldBe(command.Image);
            result.Ingredients.ShouldNotBeNull();
            result.Ingredients.Count().ShouldBe(3);

            foreach (var ingredient in result.Ingredients)
                command.SelectedIngredientIds.Contains(ingredient.Id).ShouldBeTrue();
        }

        public async Task Should_Edit_Recipe(RecipeCreateEditCommand command, IEnumerable<Data.Ingredient> ingredients, string newTitle, string newDesc)
        {
            await Insert(ingredients);
            command.SelectedIngredientIds = ingredients.Select(x => x.Id);
            var recipeId = await Send(command);

            await editRecipe();

            var results = await Send(new RecipeSearchQuery { Id = recipeId });

            var result = results.SingleOrDefault();

            result.Id.ShouldBeGreaterThan(0);
            result.Title.ShouldBe(newTitle);
            result.Description.ShouldBe(newDesc);
            result.Image.ShouldBe(command.Image);
            result.Ingredients.ShouldNotBeNull();
            result.Ingredients.Count().ShouldBe(0);

            async Task editRecipe()
            {
                command.Id = recipeId;
                command.SelectedIngredientIds = new int[0];
                command.Title = newTitle;
                command.Description = newDesc;
                await Send(command);
            }
        }
    }
}
