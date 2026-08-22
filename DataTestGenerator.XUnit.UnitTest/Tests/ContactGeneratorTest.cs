namespace Nivaes.DataTestGenerator.Xunit.UnitTest
{
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
                var contact = ContactGenerator.GenerateExtenderContact();

                contact.ShouldNotBeNull();
                eMails.ShouldNotContain(contact.Email);
                Assert.DoesNotContain(contact.Email, eMails);
                eMails.Add(contact.Email!);
                mOutput.WriteLine($"{contact.SortName} --- {contact.LongName} ---- {contact.GivenName}  ---- {contact.FamilyName} ----- {contact.Email} ---- {contact.TelephoneNumber}");
            }
        }

        [Theory]
        [GenerateContactInlineData(DataNumber = 10)]
        public void ContactGeneratorExtenderContactTest(ContactTest contact)
        {
            contact.ShouldNotBeNull();
            contact.GivenName.ShouldNotBeNullOrWhiteSpace();
            contact.FamilyName.ShouldNotBeNullOrWhiteSpace();
            contact.LongName.ShouldNotBeNullOrWhiteSpace();
            contact.SortName.ShouldNotBeNullOrWhiteSpace();
            contact.Email.ShouldNotBeNullOrWhiteSpace();
            contact.TelephoneNumber.ShouldNotBeNullOrWhiteSpace();
            mOutput.WriteLine($"{contact?.SortName} --- {contact?.LongName} ---- {contact?.GivenName}  ---- {contact?.FamilyName} ----- {contact?.Email} ---- {contact?.TelephoneNumber}");
        }
    }
}
