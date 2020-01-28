namespace Nivaes.DataTestGenerator.Xunit
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using global::Xunit.Sdk;

    [DataDiscoverer("Nivaes.DataTestGenerator.Xunit.GenericGeneratorDataDiscoverer", "Nivaes.DataTestGenerator.Xunit")]
    [XunitTestCaseDiscoverer("Nivaes.DataTestGenerator.Xunit.GeneratePasswordCaseDiscoverer", "Nivaes.DataTestGenerator.Xunit")]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public sealed class GeneratePasswordInlineDataAttribute
        : DataAttribute
    {
        public int DataNumber { get; set; } = 1;

        public int Length { get; set; } = 0;

        public string CharacterSet { get; set; }

        public GeneratePasswordInlineDataAttribute()
        { }

        public GeneratePasswordInlineDataAttribute(int dataNumber)
        {
            DataNumber = dataNumber;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            for (int i = 0; i < DataNumber; i++)
            {
                yield return new[] { PasswordGenerator.Instance.GeneratePassword(Length, CharacterSet) };
            }
        }
    }
}
