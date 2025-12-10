using Xunit.Sdk;
using Xunit.v3;

namespace Nivaes.DataTestGenerator.Xunit
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public class GeneratorDoubleCase
        : XunitTestCase
    {
        private int mDataNumber { get; set; } = 1;

        private double mMaxValue { get; set; } = 1;

        private double mMinValue { get; set; } = 1;

        [EditorBrowsable(EditorBrowsableState.Never)]
        //public GeneratorDoubleCase(IMessageSink diagnosticMessageSink, TestMethodDisplay defaultMethodDisplay, TestMethodDisplayOptions defaultMethodDisplayOptions, ITestMethod testMethod,
        //    int dataNumber, double maxValue, double minValue)
        //    : base(diagnosticMessageSink, defaultMethodDisplay, defaultMethodDisplayOptions, testMethod, testMethodArguments: null)
        public GeneratorDoubleCase(IXunitTestMethod testMethod, string testCaseDisplayName, string uniqueID,
                bool @explicit, Type[]? skipExceptions = null, string? skipReason = null,
                Type? skipType = null, string? skipUnless = null, string? skipWhen = null,
                Dictionary<string, HashSet<string>>? traits = null, object?[]? testMethodArguments = null,
                string? sourceFilePath = null, int? sourceLineNumber = null, int? timeout = null)
            : base(testMethod, testCaseDisplayName, uniqueID, @explicit, skipExceptions, skipReason,
                  skipType, skipUnless, skipWhen, traits, testMethodArguments, sourceFilePath,
                  sourceLineNumber, timeout)
        {
            //mDataNumber = dataNumber;
            //mMaxValue = maxValue;
            //mMinValue = minValue;
        }

        //public override void Serialize(IXunitSerializationInfo data)
        //{
        //    if (data == null) throw new ArgumentNullException(nameof(data));

        //    base.Serialize(data);

        //    data.AddValue("DataNumber", mDataNumber);
        //    data.AddValue("MaxValue", mMaxValue);
        //    data.AddValue("MinValue", mMinValue);
        //}

        //public override void Deserialize(IXunitSerializationInfo data)
        //{
        //    if (data == null) throw new ArgumentNullException(nameof(data));

        //    base.Deserialize(data);

        //    mDataNumber = data.GetValue<int>("DataNumber");
        //    mMaxValue = data.GetValue<double>("MaxValue");
        //    mMinValue = data.GetValue<double>("MinValue");
        //}
    }
}
