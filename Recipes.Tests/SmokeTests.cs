using Shouldly;
using System.Threading.Tasks;
using static Recipes.Tests.TestHelper;

namespace Recipes.Tests
{
    using Data;

    public class SmokeTests
    {
        public async Task ShouldSaveRecipe(Recipe recipe)
        {
            await Insert(recipe);

            var result = await Find<Recipe>(recipe.Id);

            result.Id.ShouldBeGreaterThan(0);
            result.Title.ShouldBe(recipe.Title);
            result.Description.ShouldBe(recipe.Description);
            result.Image.ShouldBe(recipe.Image);
        }
    }
}
