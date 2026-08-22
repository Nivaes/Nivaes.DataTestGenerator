using Xunit.Sdk;
using Xunit.v3;

namespace Nivaes.DataTestGenerator.Xunit
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading.Tasks;

    //[XunitTestCaseDiscoverer(typeof(GenerateStringCaseDiscoverer))]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public sealed class GenerateStringInlineDataAttribute
        : DataAttribute
    {
        public int DataNumber { get; set; } = 1;

        public int MaxSize { get; set; } = 1;

        public int MinSize { get; set; } = 1;

        public GenerateStringInlineDataAttribute()
        { }

        public GenerateStringInlineDataAttribute(int dataNumber)
        {
            DataNumber = dataNumber;
        }

        public override ValueTask<IReadOnlyCollection<ITheoryDataRow>> GetData(MethodInfo testMethod, DisposalTracker disposalTracker)
        {
            var data = new GenerateStringTheoryData(DataNumber, MinSize, MaxSize);
            return new (data);
        }

        public override bool SupportsDiscoveryEnumeration()
        {
            return true;
        }
    }
}
