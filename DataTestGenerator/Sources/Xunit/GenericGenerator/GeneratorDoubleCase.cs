namespace Nivaes.DataTestGenerator.Xunit
{
    using System.ComponentModel;
    using global::Xunit.Abstractions;
    using global::Xunit.Sdk;

    public class GeneratorDoubleCase
        : XunitTestCase
    {
        private int mDataNumber { get; set; } = 1;

        private double mMaxValue { get; set; } = 1;

        private double mMinValue { get; set; } = 1;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public GeneratorDoubleCase(IMessageSink diagnosticMessageSink, TestMethodDisplay defaultMethodDisplay, TestMethodDisplayOptions defaultMethodDisplayOptions, ITestMethod testMethod,
            int dataNumber, double maxValue, double minValue)
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
            mMaxValue = data.GetValue<double>("MaxValue");
            mMinValue = data.GetValue<double>("MinValue");
        }
    }
}
