using Xunit;
using Xunit.v3;
using Xunit.Sdk;

namespace Nivaes.DataTestGenerator.Xunit
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading.Tasks;

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public sealed class GenerateDoubleInlineDataAttribute
        : DataAttribute
    {
        public int DataNumber { get; private set; }

        public double MaxValue { get; private set; }

        public double MinValue { get; private set; }

        public GenerateDoubleInlineDataAttribute(double minValue, double maxValue)
        {
            DataNumber = 1;
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public GenerateDoubleInlineDataAttribute(int dataNumber, double minValue, double maxValue)
        {
            DataNumber = dataNumber;
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public override ValueTask<IReadOnlyCollection<ITheoryDataRow>> GetData(MethodInfo testMethod, DisposalTracker disposalTracker)
        {
            var data = new GenerateDoubleTheoryData(DataNumber, MinValue, MaxValue);
            return new(data);
        }

        public override bool SupportsDiscoveryEnumeration()
        {
            return true;
        }
    }
}
