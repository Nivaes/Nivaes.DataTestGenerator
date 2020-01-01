namespace Nivaes.DataTestGenerator.Xunit
{
    using System.ComponentModel;
    using global::Xunit.Abstractions;
    using global::Xunit.Sdk;

    public class GeneratorIntCase
        : XunitTestCase
    {
        private int mDataNumber { get; set; } = 1;

        private int mMaxValue { get; set; } = 1;

        private int mMinValue { get; set; } = 1;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public GeneratorIntCase(IMessageSink diagnosticMessageSink, TestMethodDisplay defaultMethodDisplay, TestMethodDisplayOptions defaultMethodDisplayOptions, ITestMethod testMethod,
            int dataNumber, int maxValue, int minValue)
            : base(diagnosticMessageSink, defaultMethodDisplay, defaultMethodDisplayOptions, testMethod, testMethodArguments: null)
        {
            mDataNumber = dataNumber;
            mMaxValue = maxValue;
            mMinValue = minValue;
        }

        public override void Serialize(IXunitSerializationInfo data)
        {
            base.Serialize(data);

            data.AddValue("DataNumber", mDataNumber);
            data.AddValue("MaxValue", mMaxValue);
            data.AddValue("MinValue", mMinValue);
        }

        public override void Deserialize(IXunitSerializationInfo data)
        {
            base.Deserialize(data);

            mDataNumber = data.GetValue<int>("DataNumber");
            mMaxValue = data.GetValue<int>("MaxValue");
            mMinValue = data.GetValue<int>("MinValue");
        }
    }
}
