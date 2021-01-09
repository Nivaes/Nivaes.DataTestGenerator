using Xunit.Abstractions;
using Xunit.Sdk;

namespace Nivaes.DataTestGenerator.Xunit
{
    using System;
    using System.ComponentModel;

    public class GeneratorStringCase
        : XunitTestCase
    {
        private int mDataNumber { get; set; } = 1;

        private int mMaxSize { get; set; } = 1;

        private int mMinSize { get; set; } = 1;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public GeneratorStringCase(IMessageSink diagnosticMessageSink, TestMethodDisplay defaultMethodDisplay, TestMethodDisplayOptions defaultMethodDisplayOptions, ITestMethod testMethod,
            int dataNumber, int maxSize, int minSize)
            : base(diagnosticMessageSink, defaultMethodDisplay, defaultMethodDisplayOptions, testMethod, testMethodArguments: null)
        {
            mDataNumber = dataNumber;
            mMaxSize = maxSize;
            mMinSize = minSize;
        }

        public override void Serialize(IXunitSerializationInfo data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            base.Serialize(data);

            data.AddValue("DataNumber", mDataNumber);
            data.AddValue("MaxSize", mMaxSize);
            data.AddValue("MinSize", mMinSize);
        }

        public override void Deserialize(IXunitSerializationInfo data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            base.Deserialize(data);

            mDataNumber = data.GetValue<int>("DataNumber");
            mMaxSize = data.GetValue<int>("MaxSize");
            mMinSize = data.GetValue<int>("MinSize");
        }
    }
}
