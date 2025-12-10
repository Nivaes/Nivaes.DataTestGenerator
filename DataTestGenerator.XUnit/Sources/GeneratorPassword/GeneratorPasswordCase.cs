//using Xunit.Sdk;
//using Xunit.v3;

//namespace Nivaes.DataTestGenerator.Xunit
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel;

//    public class GeneratorPasswordCase
//        : XunitTestCase
//    {
//        private int mDataNumber { get; set; } = 1;

//        private int mMaxSize { get; set; } = 1;

//        private int mMinSize { get; set; } = 1;

//        [EditorBrowsable(EditorBrowsableState.Never)]
//        //public GeneratorPasswordCase(IMessageSink diagnosticMessageSink, TestMethodDisplay defaultMethodDisplay, TestMethodDisplayOptions defaultMethodDisplayOptions, ITestMethod testMethod,
//        //    int dataNumber, int maxSize, int minSize)
//        //    : base(diagnosticMessageSink, defaultMethodDisplay, defaultMethodDisplayOptions, testMethod, testMethodArguments: null)
//        public GeneratorPasswordCase(IXunitTestMethod testMethod, string testCaseDisplayName, string uniqueID,
//                bool @explicit, Type[]? skipExceptions = null, string? skipReason = null,
//                Type? skipType = null, string? skipUnless = null, string? skipWhen = null,
//                Dictionary<string, HashSet<string>>? traits = null, object?[]? testMethodArguments = null,
//                string? sourceFilePath = null, int? sourceLineNumber = null, int? timeout = null)
//            : base(testMethod, testCaseDisplayName, uniqueID, @explicit, skipExceptions, skipReason,
//                  skipType, skipUnless, skipWhen, traits, testMethodArguments, sourceFilePath,
//                  sourceLineNumber, timeout)
//        {
//            //mDataNumber = dataNumber;
//            //mMaxSize = maxSize;
//            //mMinSize = minSize;
//        }

//        //public override void Serialize(IXunitSerializationInfo data)
//        //{
//        //    if (data == null) throw new ArgumentNullException(nameof(data));

//        //    base.Serialize(data);

//        //    data.AddValue("DataNumber", mDataNumber);
//        //    data.AddValue("MaxSize", mMaxSize);
//        //    data.AddValue("MinSize", mMinSize);
//        //}

//        //public override void Deserialize(IXunitSerializationInfo data)
//        //{
//        //    if (data == null) throw new ArgumentNullException(nameof(data));

//        //    base.Deserialize(data);

//        //    mDataNumber = data.GetValue<int>("DataNumber");
//        //    mMaxSize = data.GetValue<int>("MaxSize");
//        //    mMinSize = data.GetValue<int>("MinSize");
//        //}
//    }
//}
