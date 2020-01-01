namespace Nivaes.DataTestGenerator.Xunit
{
    using System.Collections.Generic;
    using System.Reflection;
    using global::Xunit.Sdk;

    [DataDiscoverer("Nivaes.DataTestGenerator.Xunit.GenericGeneratorDataDiscoverer", "Nivaes.DataTestGenerator")]
    [XunitTestCaseDiscoverer("Nivaes.DataTestGenerator.Xunit.GenerateDoubleCaseDiscoverer", "Nivaes.DataTestGenerator")]
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

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            for (int i = 0; i < DataNumber; i++)
            {
                yield return new object[] { GenericGenerator.Instance.GenerateDouble(MinValue, MaxValue) };
            }
        }
    }
}
