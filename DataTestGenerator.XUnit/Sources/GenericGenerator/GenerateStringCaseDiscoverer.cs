using Xunit.Abstractions;
using Xunit.Sdk;

namespace Nivaes.DataTestGenerator.Xunit
{
    using System;
    using System.Collections.Generic;

    public sealed class GenerateStringCaseDiscoverer
        : IXunitTestCaseDiscoverer
    {
        private readonly IMessageSink mDiagnosticMessageSink;

        public GenerateStringCaseDiscoverer(IMessageSink diagnosticMessageSink)
        {
            mDiagnosticMessageSink = diagnosticMessageSink;
        }

        public IEnumerable<IXunitTestCase> Discover(ITestFrameworkDiscoveryOptions discoveryOptions, ITestMethod testMethod, IAttributeInfo factAttribute)
        {
            if (factAttribute == null) throw new ArgumentNullException(nameof(factAttribute));

            var dataNumber = factAttribute.GetNamedArgument<int>(nameof(GenerateStringInlineDataAttribute.DataNumber));
            if (dataNumber < 1)
                dataNumber = 1;

            var maxSize = factAttribute.GetNamedArgument<int>(nameof(GenerateStringInlineDataAttribute.MaxSize));
            if (maxSize < 1)
                maxSize = 1;

            var minSize = factAttribute.GetNamedArgument<int>(nameof(GenerateStringInlineDataAttribute.MinSize));
            if (minSize < 1)
                minSize = 1;

            yield return new GeneratorStringCase(mDiagnosticMessageSink, discoveryOptions.MethodDisplayOrDefault(), discoveryOptions.MethodDisplayOptionsOrDefault(), testMethod,
                dataNumber, maxSize, minSize);
        }
    }
}
