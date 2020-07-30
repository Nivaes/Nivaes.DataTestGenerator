using Xunit.Abstractions;
using Xunit.Sdk;

namespace Nivaes.DataTestGenerator.Xunit
{
    using System.ComponentModel;

    public class GeneratorContactCase
        : XunitTestCase
    {
        private int mDataNumber { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public GeneratorContactCase(IMessageSink diagnosticMessageSink, TestMethodDisplay defaultMethodDisplay, TestMethodDisplayOptions defaultMethodDisplayOptions, ITestMethod testMethod,
            int dataNumber)
            : base(diagnosticMessageSink, defaultMethodDisplay, defaultMethodDisplayOptions, testMethod, testMethodArguments: null)
        {
            mDataNumber = dataNumber;
        }

        public override void Serialize(IXunitSerializationInfo data)
        {
            base.Serialize(data);

            data.AddValue("DataNumber", mDataNumber);
        }

        public override void Deserialize(IXunitSerializationInfo data)
        {
            base.Deserialize(data);

            mDataNumber = data.GetValue<int>("DataNumber");
        }
    }
}
