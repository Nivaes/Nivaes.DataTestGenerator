using Xunit.Abstractions;
using Xunit.Sdk;

namespace Nivaes.DataTestGenerator.Xunit
{
    using System;
    using System.Collections.Generic;

    public sealed class GenerateDoubleCaseDiscoverer
        : IXunitTestCaseDiscoverer
    {
        private readonly IMessageSink mDiagnosticMessageSink;

        public GenerateDoubleCaseDiscoverer(IMessageSink diagnosticMessageSink)
        {
            mDiagnosticMessageSink = diagnosticMessageSink;
        }

        public IEnumerable<IXunitTestCase> Discover(ITestFrameworkDiscoveryOptions discoveryOptions, ITestMethod testMethod, IAttributeInfo factAttribute)
        {
            if (factAttribute == null) throw new ArgumentNullException(nameof(factAttribute));

            var dataNumber = factAttribute.GetNamedArgument<int>(nameof(GenerateDoubleInlineDataAttribute.DataNumber));
            if (dataNumber < 1)
                dataNumber = 1;

            var maxValue = factAttribute.GetNamedArgument<double>(nameof(GenerateDoubleInlineDataAttribute.MaxValue));
            if (maxValue < 1)
                maxValue = 1;

            var minvalue = factAttribute.GetNamedArgument<double>(nameof(GenerateDoubleInlineDataAttribute.MinValue));
            if (minvalue < 1)
                minvalue = 1;

            yield return new GeneratorDoubleCase(mDiagnosticMessageSink, discoveryOptions.MethodDisplayOrDefault(), discoveryOptions.MethodDisplayOptionsOrDefault(), testMethod,
                dataNumber, maxValue, minvalue);
        }
    }
}
