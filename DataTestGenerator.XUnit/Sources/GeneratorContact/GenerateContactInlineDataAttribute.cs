namespace Nivaes.DataTestGenerator.Xunit
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using global::Xunit.Sdk;

    [DataDiscoverer("Nivaes.DataTestGenerator.Xunit.GenericGeneratorDataDiscoverer", "Nivaes.DataTestGenerator.Xunit")]
    [XunitTestCaseDiscoverer("Nivaes.DataTestGenerator.Xunit.GenerateContactCaseDiscoverer", "Nivaes.DataTestGenerator.Xunit")]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public sealed class GenerateContactInlineDataAttribute
        : DataAttribute
    {
        public int DataNumber { get; set; } = 1;

        public GenerateContactInlineDataAttribute()
        { }

        public GenerateContactInlineDataAttribute(int dataNumber)
        {
            DataNumber = dataNumber;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            for (int i = 0; i < DataNumber; i++)
            {
                yield return new[] { ContactGenerator.Instance.GenerateContact() };
            }
        }
    }
}
