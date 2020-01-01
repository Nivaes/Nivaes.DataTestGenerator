namespace Nivaes.DataTestGenerator.Xunit
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using global::Xunit;
    using global::Xunit.Sdk;

    /// <summary>
    /// Works just like [Fact] except that failures are retried (by default, 3 times).
    /// </summary>
    [DataDiscoverer("Xunit.Sdk.InlineDataDiscoverer", "xunit.core")]
    [XunitTestCaseDiscoverer("Nivaes.DataTestGenerator.Xunit.RetryInlineCaseDiscoverer", "Nivaes.DataTestGenerator")]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]    
    public sealed class RetryInlineDataAttribute
        : DataAttribute
    {
        private readonly object[] mData;

        public RetryInlineDataAttribute(params object[] data)
        {
            mData = data;
        }

        /// <summary>
        /// Number of retries allowed for a failed test. If unset (or set less than 1), will
        /// default to 3 attempts.
        /// </summary>
        public int MaxRetries { get; set; }

        /// <summary>
        /// Time spleep in miliseconst for retry.
        /// </summary>
        public int TimeSleep { get; set; }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            // This is called by the WPA81 version as it does not have access to attribute ctor params
            return new[] { mData };
        }
    }
}
