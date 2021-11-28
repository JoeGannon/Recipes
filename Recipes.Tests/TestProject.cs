using Fixie;

namespace Recipes.Tests
{
    public class TestProject : ITestProject
    {
        public void Configure(TestConfiguration configuration, TestEnvironment environment)
        {
            configuration.Conventions.Add<DefaultDiscovery, ParameterizedExecution>();
        }
    }
}
