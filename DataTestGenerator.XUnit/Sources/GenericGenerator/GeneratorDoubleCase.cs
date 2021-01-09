using Xunit.Abstractions;
using Xunit.Sdk;

namespace Nivaes.DataTestGenerator.Xunit
{
    using System;
    using System.ComponentModel;

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
            if (data == null) throw new ArgumentNullException(nameof(data));

            base.Serialize(data);

            data.AddValue("DataNumber", mDataNumber);
            data.AddValue("MaxValue", mMaxValue);
            data.AddValue("MinValue", mMinValue);
        }

        public override void Deserialize(IXunitSerializationInfo data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            base.Deserialize(data);

            mDataNumber = data.GetValue<int>("DataNumber");
            mMaxValue = data.GetValue<double>("MaxValue");
            mMinValue = data.GetValue<double>("MinValue");
        }
    }
}
