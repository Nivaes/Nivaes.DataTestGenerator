namespace Nivaes.DataTestGenerator.Xunit
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using global::Xunit.Sdk;

    [DataDiscoverer("Nivaes.DataTestGenerator.Xunit.GenericGeneratorDataDiscoverer", "Nivaes.DataTestGenerator.Xunit")]
    [XunitTestCaseDiscoverer("Nivaes.DataTestGenerator.Xunit.GenerateIntCaseDiscoverer", "Nivaes.DataTestGenerator.Xunit")]
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

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            for (int i = 0; i < DataNumber; i++)
            {
                yield return new object[] { GenericGenerator.Instance.GenerateInt(MinValue, MaxValue) };
            }
        }
    }
}
