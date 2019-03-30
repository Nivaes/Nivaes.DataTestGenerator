namespace Nivaes.DataTestGenerator.UnitTest.Tests
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using Xunit;

    public class ContactProporcionalGeneratorTest
    {
        [Fact]
        public void ContactProporcionalGeneratorTest01()
        {
            for (int i = 0; i < 10; i++)
            {
                var name = ContactProporcionalGenerator.Instance.GenerateName();
                Debug.Print(name);
            }
        }

        [Fact]
        public void ContactProporcionalGeneratorTest02()
        {
            for (int i = 0; i < 100; i++)
            {
                var contact = ContactProporcionalGenerator.Instance.GenerateContact();
                Debug.Print($"{contact.SortName} --- {contact.LongName} ---- {contact.PersonalName}  ---- {contact.FamilyName} ----- {contact.Email} ---- {contact.TelephoneNumber}");
            }
        }
    }
}
