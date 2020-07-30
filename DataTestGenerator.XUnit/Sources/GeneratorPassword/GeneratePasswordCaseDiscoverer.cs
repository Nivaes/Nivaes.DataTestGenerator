using Xunit.Abstractions;
using Xunit.Sdk;

namespace Nivaes.DataTestGenerator.Xunit
{
    using System;
    using System.Collections.Generic;

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
            dataNumber = Math.Max(1, dataNumber);

            var length = factAttribute.GetNamedArgument<int>(nameof(GeneratePasswordInlineDataAttribute.Length));
            length = Math.Max(1, length);

            var characterSet = factAttribute.GetNamedArgument<int>(nameof(GeneratePasswordInlineDataAttribute.CharacterSet));
            characterSet = Math.Max(1, characterSet);

            yield return new GeneratorPasswordCase(mDiagnosticMessageSink, discoveryOptions.MethodDisplayOrDefault(), discoveryOptions.MethodDisplayOptionsOrDefault(), testMethod,
                dataNumber, length, characterSet);
        }
    }
}
