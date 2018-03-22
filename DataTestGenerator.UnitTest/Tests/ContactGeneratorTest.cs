namespace Nivaes.DataTestGenerator.UnitTest.Tests
{
    using System.Diagnostics;
    using Xunit;

    [Collection("ContactGenerator")]
    public class ContactGeneratorTest
    {
        [Fact]
        public void  ContactGeneratorTest01()
        {
            for (int i = 0; i < 10; i++)
            {
                var name = ContactGenerator.GenerateName();
                Debug.Print(name);
            }
        }

        [Fact]
        public void ContactGeneratorTest02()
        {
            for (int i = 0; i < 100; i++)
            {
                var contact = ContactGenerator.GenerateContact();
                Debug.Print($"{contact.SortName} --- {contact.LongName} ---- {contact.FirstName}  ---- {contact.SecondName} ----- {contact.Email} ---- {contact.TelephoneNumber}");
            }
        }
    }
}
