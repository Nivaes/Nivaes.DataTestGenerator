using Xunit.Sdk;
using Xunit.v3;

namespace Nivaes.DataTestGenerator.Xunit
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class GenericGeneratorDataDiscoverer
        : IXunitTestCaseDiscoverer
    {
        public ValueTask<IReadOnlyCollection<IXunitTestCase>> Discover(ITestFrameworkDiscoveryOptions discoveryOptions, IXunitTestMethod testMethod, IFactAttribute factAttribute)
        {
            throw new System.NotImplementedException();
        }
    }
}
