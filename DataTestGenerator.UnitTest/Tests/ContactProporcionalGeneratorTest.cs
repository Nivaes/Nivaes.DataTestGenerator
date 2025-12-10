namespace Nivaes.DataTestGenerator.UnitTest
{
    using System.Xml.Linq;
    using FluentAssertions;
    using Xunit;

    public class ContactProporcionalGeneratorTest
    {
        private readonly ITestOutputHelper mOutput;

        public ContactProporcionalGeneratorTest(ITestOutputHelper output)
        {
            mOutput = output;
        }

        [Fact]
        public void ContactProporcionalGeneratorTest01()
        {
            for (int i = 0; i < 10; i++)
            {
                var name = ContactProporcionalGenerator.Instance.GenerateName();
                name.Should().NotBeNullOrWhiteSpace();
                mOutput.WriteLine(name);
            }
        }

        [Fact]
        public void ContactProporcionalGeneratorTest02()
        {
            for (int i = 0; i < 100; i++)
            {
                var contact = ContactProporcionalGenerator.Instance.GenerateContact();
                contact.Should().NotBeNull();
                contact.GivenName.Should().NotBeNullOrWhiteSpace();
                contact.FamilyName.Should().NotBeNullOrWhiteSpace();
                contact.LongName.Should().NotBeNullOrWhiteSpace();
                contact.SortName.Should().NotBeNullOrWhiteSpace();
                contact.Email.Should().NotBeNullOrWhiteSpace();
                contact.TelephoneNumber.Should().NotBeNullOrWhiteSpace();
                mOutput.WriteLine($"{contact.SortName} --- {contact.LongName} ---- {contact.GivenName}  ---- {contact.FamilyName} ----- {contact.Email} ---- {contact.TelephoneNumber}");
            }
        }
    }
}
