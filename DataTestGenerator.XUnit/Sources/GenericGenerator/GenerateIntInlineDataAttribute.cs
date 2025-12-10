using Xunit;
using Xunit.Sdk;
using Xunit.v3;

namespace Nivaes.DataTestGenerator.Xunit
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading.Tasks;

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public sealed class GenerateIntInlineDataAttribute
        : DataAttribute
    {
        public int DataNumber { get; set; } = 1;

        public int MaxValue { get; set; } = 1;

        public int MinValue { get; set; } = 1;

        public GenerateIntInlineDataAttribute()
        { }

        public GenerateIntInlineDataAttribute(int dataNumber)
        {
            DataNumber = dataNumber;
        }

        public override ValueTask<IReadOnlyCollection<ITheoryDataRow>> GetData(MethodInfo testMethod, DisposalTracker disposalTracker)
        {
            var data = new GenerateIntTheoryData(DataNumber, MinValue, MaxValue);
            return new(data);
        }

        public override bool SupportsDiscoveryEnumeration()
        {
            return true;
        }
    }
}
