namespace Nivaes.DataTestGenerator.Xunit
{
    using System.Collections.Generic;
    using global::Xunit.Abstractions;
    using global::Xunit.Sdk;

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
