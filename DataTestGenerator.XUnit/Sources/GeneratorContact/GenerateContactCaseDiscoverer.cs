//using Xunit.Sdk;
//using Xunit.v3;

//namespace Nivaes.DataTestGenerator.Xunit
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Diagnostics.CodeAnalysis;
//    using System.Threading.Tasks;
//    using global::Xunit.Internal;

//    public sealed class GenerateContactCaseDiscoverer
//        : IXunitTestCaseDiscoverer
//    {
//        private readonly IMessageSink mDiagnosticMessageSink;

//        public GenerateContactCaseDiscoverer(IMessageSink diagnosticMessageSink)
//        {
//            mDiagnosticMessageSink = diagnosticMessageSink;
//        }

//        public ValueTask<IReadOnlyCollection<IXunitTestCase>> Discover(ITestFrameworkDiscoveryOptions discoveryOptions, IXunitTestMethod testMethod, IFactAttribute factAttribute)
//        {
//            var maxRetries = (factAttribute as RetryFactAttribute)?.MaxRetries ?? 3;
//            var details = TestIntrospectionHelper.GetTestCaseDetails(discoveryOptions, testMethod, factAttribute, null, null, string.Empty, string.Empty);
//            var testCase = new RetryTestCase(
//                maxRetries,
//                details.ResolvedTestMethod,
//                "wuenas",//details.TestCaseDisplayName,
//                details.UniqueID,
//                details.Explicit,
//                details.SkipExceptions,
//                details.SkipReason,
//                details.SkipType,
//                details.SkipUnless,
//                details.SkipWhen,
//                testMethod.Traits.ToReadWrite(StringComparer.OrdinalIgnoreCase),
//                timeout: details.Timeout
//            );

//            return new([testCase]);
//        }
//    }
//}
