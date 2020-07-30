using Xunit.Abstractions;
using Xunit.Sdk;

namespace Nivaes.DataTestGenerator.Xunit
{
    using System;
    using System.Collections.Generic;

    public sealed class GenerateContactCaseDiscoverer
        : IXunitTestCaseDiscoverer
    {
        private readonly IMessageSink mDiagnosticMessageSink;

        public GenerateContactCaseDiscoverer(IMessageSink diagnosticMessageSink)
        {
            mDiagnosticMessageSink = diagnosticMessageSink;
        }

        public IEnumerable<IXunitTestCase> Discover(ITestFrameworkDiscoveryOptions discoveryOptions, ITestMethod testMethod, IAttributeInfo factAttribute)
        {
            var dataNumber = factAttribute.GetNamedArgument<int>(nameof(GenerateContactInlineDataAttribute.DataNumber));
            dataNumber = Math.Max(1, dataNumber);

            yield return new GeneratorContactCase(mDiagnosticMessageSink, discoveryOptions.MethodDisplayOrDefault(), discoveryOptions.MethodDisplayOptionsOrDefault(), testMethod,
                dataNumber);
        }
    }
}
