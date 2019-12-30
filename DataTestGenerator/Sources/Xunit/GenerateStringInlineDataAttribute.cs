namespace Nivaes.DataTestGenerator
{
    using System.Collections.Generic;
    using System.Reflection;
    using Xunit.Sdk;

    public sealed class GenerateStringInlineDataAttribute : DataAttribute
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

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            for (int i = 0; i < DataNumber; i++)
            {
                yield return new[] { TestGenericGenerator.Instance.GenerateString(MinSize, MaxSize) };
            }
        }
    }
}
