namespace Nivaes.DataTestGenerator.Xunit
{
    using System.ComponentModel;
    using global::Xunit.Abstractions;
    using global::Xunit.Sdk;

    public class GenericGeneratorCase
        : XunitTestCase
    {
        private int mDataNumber { get; set; } = 1;

        private int mMaxSize { get; set; } = 1;

        private int mMinSize { get; set; } = 1;

        [EditorBrowsable(EditorBrowsableState.Never)]

        public GenericGeneratorCase(IMessageSink diagnosticMessageSink, TestMethodDisplay defaultMethodDisplay, TestMethodDisplayOptions defaultMethodDisplayOptions, ITestMethod testMethod,
            int dataNumber, int maxSize, int minSize)
            : base(diagnosticMessageSink, defaultMethodDisplay, defaultMethodDisplayOptions, testMethod, testMethodArguments: null)
        {
            mDataNumber = dataNumber;
            mMaxSize = maxSize;
            mMinSize = minSize;
        }

        public override void Serialize(IXunitSerializationInfo data)
        {
            base.Serialize(data);

            data.AddValue("DataNumber", mDataNumber);
            data.AddValue("MaxSize", mMaxSize);
            data.AddValue("MinSize", mMinSize);
        }

        public override void Deserialize(IXunitSerializationInfo data)
        {
            base.Deserialize(data);

            mDataNumber = data.GetValue<int>("DataNumber");
            mMaxSize = data.GetValue<int>("MaxSize");
            mMinSize = data.GetValue<int>("MinSize");
        }
    }
}
