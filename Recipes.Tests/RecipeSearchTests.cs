namespace Recipes.Tests
{
    using Data;
    using Recipes.Features.Search;
    using Shouldly;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using static TestHelper;

    public class RecipeSearchTests
    {
        public async Task Should_Query_By_Id(Recipe recipe, Recipe control)
        {
            await Insert(recipe, control);

            var results = await Send(new RecipeSearchQuery { Id = recipe.Id });

            var result = results.SingleOrDefault();

            result.ShouldNotBeNull();
            result.Id.ShouldBe(recipe.Id);
            result.Title.ShouldBe(recipe.Title);
            result.Description.ShouldBe(recipe.Description);
            result.Image.ShouldBe(recipe.Image);
            result.Ingredients.Count().ShouldBe(3);
            result.Instructions.Count().ShouldBe(3);
        }

        public async Task Should_Query_By_Description(Recipe recipe, Recipe control, Guid desc)
        {
            recipe.Description = desc.ToString();
            await Insert(recipe, control);

            var results = await Send(new RecipeSearchQuery { Query = recipe.Description.Substring(0, recipe.Description.Length - 2) });

            var result = results.SingleOrDefault();

            result.ShouldNotBeNull();
            result.Id.ShouldBe(recipe.Id);
            result.Title.ShouldBe(recipe.Title);
            result.Description.ShouldBe(recipe.Description);
            result.Image.ShouldBe(recipe.Image);
            result.Ingredients.Count().ShouldBe(3);
            result.Instructions.Count().ShouldBe(3);
        }
    }
}
