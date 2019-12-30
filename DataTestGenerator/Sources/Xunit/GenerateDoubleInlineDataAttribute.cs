namespace Nivaes.DataTestGenerator
{
    using System.Collections.Generic;
    using System.Reflection;
    using Xunit.Sdk;

    public sealed class GenerateDoubleInlineDataAttribute : DataAttribute
    {
        private readonly int mDataNumber;

        private readonly double mMaxValue;

        private readonly double mMinValue;

        public GenerateDoubleInlineDataAttribute(double minValue, double maxValue)
        {
            mDataNumber = 1;
            mMinValue = minValue;
            mMaxValue = maxValue;
        }

        public GenerateDoubleInlineDataAttribute(int dataNumber, double minValue, double maxValue)
        {
            mDataNumber = dataNumber;
            mMinValue = minValue;
            mMaxValue = maxValue;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            for (int i = 0; i < mDataNumber; i++)
            {
                yield return new object[] { TestGenericGenerator.Instance.GenerateDouble(mMinValue, mMaxValue) };
            }
        }
    }
}
