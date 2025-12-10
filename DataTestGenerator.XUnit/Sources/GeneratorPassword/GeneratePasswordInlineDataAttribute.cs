using Xunit;
using Xunit.v3;

namespace Nivaes.DataTestGenerator.Xunit
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading.Tasks;
    using global::Xunit.Sdk;

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public sealed class GeneratePasswordInlineDataAttribute
        : DataAttribute
    {
        public int DataNumber { get; set; } = 1;

        public int Length { get; set; }

        public string? CharacterSet { get; set; }

        public GeneratePasswordInlineDataAttribute()
        { }

        public GeneratePasswordInlineDataAttribute(int dataNumber)
        {
            DataNumber = dataNumber;
        }

        public override ValueTask<IReadOnlyCollection<ITheoryDataRow>> GetData(MethodInfo testMethod, DisposalTracker disposalTracker)
        {
            var data = new GeneratePasswordTheoryData(DataNumber, Length, CharacterSet);
            return new(data);
        }

        public override bool SupportsDiscoveryEnumeration()
        {
            return true;
        }
    }
}
