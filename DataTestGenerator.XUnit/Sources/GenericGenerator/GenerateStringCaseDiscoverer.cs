namespace Nivaes.DataTestGenerator.Xunit
{
    using System.Collections.Generic;
    using global::Xunit.Abstractions;
    using global::Xunit.Sdk;

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
