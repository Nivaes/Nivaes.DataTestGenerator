using Xunit.Sdk;
using Xunit.v3;

namespace Nivaes.DataTestGenerator.Xunit
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading.Tasks;

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public sealed class GenerateContactInlineDataAttribute
        : DataAttribute
    {
        public int DataNumber { get; set; } = 1;

        public GenerateContactInlineDataAttribute()
        { }

        public GenerateContactInlineDataAttribute(int dataNumber)
        {
            DataNumber = dataNumber;
        }

        public override ValueTask<IReadOnlyCollection<ITheoryDataRow>> GetData(MethodInfo testMethod, DisposalTracker disposalTracker)
        {
            var data = new GenerateContactTheoryData(DataNumber);
            return new(data);
        }

        public override bool SupportsDiscoveryEnumeration()
        {
            return true;
        }
    }
}
