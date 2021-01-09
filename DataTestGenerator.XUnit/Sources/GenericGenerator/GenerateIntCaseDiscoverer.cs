using Xunit.Abstractions;
using Xunit.Sdk;

namespace Nivaes.DataTestGenerator.Xunit
{
    using System;
    using System.Collections.Generic;

    public sealed class GenerateIntCaseDiscoverer
        : IXunitTestCaseDiscoverer
    {
        private readonly IMessageSink mDiagnosticMessageSink;

        public GenerateIntCaseDiscoverer(IMessageSink diagnosticMessageSink)
        {
            mDiagnosticMessageSink = diagnosticMessageSink;
        }

        public IEnumerable<IXunitTestCase> Discover(ITestFrameworkDiscoveryOptions discoveryOptions, ITestMethod testMethod, IAttributeInfo factAttribute)
        {
            if (factAttribute == null) throw new ArgumentNullException(nameof(factAttribute));

            var dataNumber = factAttribute.GetNamedArgument<int>(nameof(GenerateIntInlineDataAttribute.DataNumber));
            if (dataNumber < 1)
                dataNumber = 1;

            var maxValue = factAttribute.GetNamedArgument<int>(nameof(GenerateIntInlineDataAttribute.MaxValue));
            if (maxValue < 1)
                maxValue = 1;

            var minValue = factAttribute.GetNamedArgument<int>(nameof(GenerateIntInlineDataAttribute.MinValue));
            if (minValue < 1)
                minValue = 1;

            yield return new GeneratorIntCase(mDiagnosticMessageSink, discoveryOptions.MethodDisplayOrDefault(), discoveryOptions.MethodDisplayOptionsOrDefault(), testMethod,
                dataNumber, maxValue, minValue);
        }
    }
}
