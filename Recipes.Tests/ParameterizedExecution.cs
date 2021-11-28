using Fixie;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recipes.Tests
{
    using Construktion;

    public class ParameterizedExecution : IExecution
    {
        private readonly Construktion _construktion;

        public ParameterizedExecution()
        {
            _construktion = new Construktion().With(x => x.OmitIds());
        }

        public async Task Run(TestSuite testSuite)
        {
            foreach (var test in testSuite.Tests)
            {
                await TestHelper.ResetDatabase();

                if (test.HasParameters)
                {
                    var parameters = new List<object>();

                    foreach (var parameter in test.Method.GetParameters())
                        parameters.Add(_construktion.Construct(parameter));

                    await test.Run(parameters.ToArray());
                }
                else
                {
                    await test.Run();
                }
            }
        }
    }
}