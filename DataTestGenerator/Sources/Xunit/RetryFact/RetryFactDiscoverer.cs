﻿namespace Nivaes.DataTestGenerator.Xunit
{
    using System.Collections.Generic;
    using global::Xunit.Abstractions;
    using global::Xunit.Sdk;

    public sealed class RetryFactDiscoverer
        : IXunitTestCaseDiscoverer
    {
        readonly IMessageSink diagnosticMessageSink;

        public RetryFactDiscoverer(IMessageSink diagnosticMessageSink)
        {
            this.diagnosticMessageSink = diagnosticMessageSink;
        }

        public IEnumerable<IXunitTestCase> Discover(ITestFrameworkDiscoveryOptions discoveryOptions, ITestMethod testMethod, IAttributeInfo factAttribute)
        {
            var maxRetries = factAttribute.GetNamedArgument<int>(nameof(RetryFactAttribute.MaxRetries));
            if (maxRetries < 1)
                maxRetries = 3;

            var timeSleep = factAttribute.GetNamedArgument<int>(nameof(RetryFactAttribute.TimeSleep));
            if (timeSleep < 0)
                timeSleep = 0;

            yield return new RetryTestCase(diagnosticMessageSink, discoveryOptions.MethodDisplayOrDefault(), discoveryOptions.MethodDisplayOptionsOrDefault(), testMethod, maxRetries, timeSleep);
        }
    }
}
