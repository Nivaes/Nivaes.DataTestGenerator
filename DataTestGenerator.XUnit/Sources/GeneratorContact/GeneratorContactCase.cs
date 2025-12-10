//using Xunit.Sdk;
//using Xunit.v3;

//namespace Nivaes.DataTestGenerator.Xunit
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel;

//    public class GeneratorContactCase
//        : XunitTestCase
//    {
//        private int mDataNumber { get; set; }

//        [EditorBrowsable(EditorBrowsableState.Never)]
//        public GeneratorContactCase(IXunitTestMethod testMethod, string testCaseDisplayName, string uniqueID,
//                bool @explicit, Type[]? skipExceptions = null, string? skipReason = null,
//                Type? skipType = null, string? skipUnless = null, string? skipWhen = null,
//                Dictionary<string, HashSet<string>>? traits = null, object?[]? testMethodArguments = null,
//                string? sourceFilePath = null, int? sourceLineNumber = null, int? timeout = null)
//            : base(testMethod, testCaseDisplayName, uniqueID, @explicit, skipExceptions, skipReason,
//                  skipType, skipUnless, skipWhen, traits, testMethodArguments, sourceFilePath,
//                  sourceLineNumber, timeout)
//        {
//            //mDataNumber = dataNumber;
//        }

//        //public override void Serialize(IXunitSerializationInfo data)
//        //{
//        //    if (data == null) throw new ArgumentNullException(nameof(data));

//        //    base.Serialize(data);

//        //    data.AddValue("DataNumber", mDataNumber);
//        //}

//        //public override void Deserialize(IXunitSerializationInfo data)
//        //{
//        //    if (data == null) throw new ArgumentNullException(nameof(data));

//        //    base.Deserialize(data);

//        //    mDataNumber = data.GetValue<int>("DataNumber");
//        //}
//    }
//}
