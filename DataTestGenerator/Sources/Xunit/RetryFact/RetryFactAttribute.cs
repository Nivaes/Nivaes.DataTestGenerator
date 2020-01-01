namespace Nivaes.DataTestGenerator.Xunit
{
    using System;
    using global::Xunit;
    using global::Xunit.Sdk;

    /// <summary>
    /// Works just like [Fact] except that failures are retried (by default, 3 times).
    /// </summary>
    [XunitTestCaseDiscoverer("Nivaes.DataTestGenerator.Xunit.RetryFactDiscoverer", "Nivaes.DataTestGenerator")]
    public sealed class RetryFactAttribute
        : FactAttribute
    {
        /// <summary>
        /// Number of retries allowed for a failed test. If unset (or set less than 1), will
        /// default to 3 attempts.
        /// </summary>
        public int MaxRetries { get; set; }

        /// <summary>
        /// Time spleep in miliseconst for retry.
        /// </summary>
        public int TimeSleep { get; set; }
    }
}
