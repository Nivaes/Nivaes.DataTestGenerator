using Xunit;

namespace Nivaes.DataTestGenerator.Xunit.UnitTest
{
    using System.Collections.Generic;
    using FluentAssertions;

    public class ContactGeneratorTest
    {
        private readonly ITestOutputHelper mOutput;

        public ContactGeneratorTest(ITestOutputHelper output)
        {
            mOutput = output;
        }

        [Fact]
        public void ContactGeneratorExtenderContactRetryTest()
        {
            List<string> eMails = new();
            for (int i = 0; i < 1000; i++)
            {
                var contact = ContactGenerator.Instance.GenerateExtenderContact();

                contact.Should().NotBeNull();
                eMails.Should().NotContain(contact.Email);
                Assert.DoesNotContain(contact.Email, eMails);
                eMails.Add(contact.Email!);
                mOutput.WriteLine($"{contact.SortName} --- {contact.LongName} ---- {contact.GivenName}  ---- {contact.FamilyName} ----- {contact.Email} ---- {contact.TelephoneNumber}");
            }
        }

        [Theory]
        [GenerateContactInlineData(DataNumber = 10)]
        public void ContactGeneratorExtenderContactTest(ContactTest contact)
        {
            contact.Should().NotBeNull();
            contact.GivenName.Should().NotBeNullOrWhiteSpace();
            contact.FamilyName.Should().NotBeNullOrWhiteSpace();
            contact.LongName.Should().NotBeNullOrWhiteSpace();
            contact.SortName.Should().NotBeNullOrWhiteSpace();
            contact.Email.Should().NotBeNullOrWhiteSpace();
            contact.TelephoneNumber.Should().NotBeNullOrWhiteSpace();
            mOutput.WriteLine($"{contact?.SortName} --- {contact?.LongName} ---- {contact?.GivenName}  ---- {contact?.FamilyName} ----- {contact?.Email} ---- {contact?.TelephoneNumber}");
        }
    }
}
