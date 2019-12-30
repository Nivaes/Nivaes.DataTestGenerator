namespace Nivaes.DataTestGenerator
{
    using System.Collections.Generic;
    using System.Reflection;
    using Xunit.Sdk;

    public sealed class GenerateIntInlineDataAttribute : DataAttribute
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
