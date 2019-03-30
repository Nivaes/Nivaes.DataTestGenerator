namespace Nivaes.DataTestGenerator.UnitTest.Tests
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using Xunit;

    public class ContactGeneratorTest
    {
        [Fact]
        public void  ContactGeneratorTest01()
        {
            for (int i = 0; i < 10; i++)
            {
                var name = ContactGenerator.Instance.GenerateName();
                Debug.Print(name);
            }
        }

        [Fact]
        public void ContactGeneratorTest02()
        {
            for (int i = 0; i < 100; i++)
            {
                var contact = ContactGenerator.Instance.GenerateContact();
                Debug.Print($"{contact.SortName} --- {contact.LongName} ---- {contact.PersonalName}  ---- {contact.FamilyName} ----- {contact.Email} ---- {contact.TelephoneNumber}");
            }
        }

        [Fact]
        public void ContactGeneratorTest03()
        {
            List<string> eMails = new List<string>();
            for (int i = 0; i < 50; i++)
            {
                var contact = ContactGenerator.Instance.GenerateContact();

                Assert.DoesNotContain(contact.Email, eMails);

                eMails.Add(contact.Email);
                Debug.Print($"{contact.SortName} --- {contact.LongName} ---- {contact.PersonalName}  ---- {contact.FamilyName} ----- {contact.Email} ---- {contact.TelephoneNumber}");
            }
        }

        [Fact]
        public void ContactGeneratorTest04()
        {
            List<string> eMails = new List<string>();
            for (int i = 0; i < 10000; i++)
            {
                var contact = ContactGenerator.Instance.GenerateExtenderContact();

                Assert.DoesNotContain(contact.Email, eMails);

                eMails.Add(contact.Email);
                Debug.Print($"{contact.SortName} --- {contact.LongName} ---- {contact.PersonalName}  ---- {contact.FamilyName} ----- {contact.Email} ---- {contact.TelephoneNumber}");
            }
        }
    }
}
