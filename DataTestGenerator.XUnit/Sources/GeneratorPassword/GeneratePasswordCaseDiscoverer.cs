namespace Nivaes.DataTestGenerator.Xunit
{
    using System.Collections.Generic;
    using global::Xunit.Abstractions;
    using global::Xunit.Sdk;

    public sealed class GeneratePasswordCaseDiscoverer
        : IXunitTestCaseDiscoverer
    {
        private readonly IMessageSink mDiagnosticMessageSink;

        public GeneratePasswordCaseDiscoverer(IMessageSink diagnosticMessageSink)
        {
            mDiagnosticMessageSink = diagnosticMessageSink;
        }

        public IEnumerable<IXunitTestCase> Discover(ITestFrameworkDiscoveryOptions discoveryOptions, ITestMethod testMethod, IAttributeInfo factAttribute)
        {
            var dataNumber = factAttribute.GetNamedArgument<int>(nameof(GeneratePasswordInlineDataAttribute.DataNumber));
            if (dataNumber < 1)
                dataNumber = 1;

            var length = factAttribute.GetNamedArgument<int>(nameof(GeneratePasswordInlineDataAttribute.Length));
            if (length < 1)
                length = 1;

            var characterSet = factAttribute.GetNamedArgument<int>(nameof(GeneratePasswordInlineDataAttribute.CharacterSet));
            if (characterSet < 1)
                characterSet = 1;

            yield return new GeneratorPasswordCase(mDiagnosticMessageSink, discoveryOptions.MethodDisplayOrDefault(), discoveryOptions.MethodDisplayOptionsOrDefault(), testMethod,
                dataNumber, length, characterSet);
        }
    }
}
