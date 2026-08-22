namespace Nivaes.DataTestGenerator.UnitTest
{
    public class ContactGeneratorTest
    {
        private readonly ITestOutputHelper mOutput;

        public ContactGeneratorTest(ITestOutputHelper output)
        {
            mOutput = output;
        }

        [Fact]
        public void ContactGeneratorName()
        {
            for (int i = 0; i < 10; i++)
            {
                var name = ContactGenerator.Instance.GenerateName();
                mOutput.WriteLine(name);
                name.ShouldNotBeNullOrEmpty();
            }
        }

        [Fact]
        public void ContactGeneratorContact01()
        {
            for (int i = 0; i < 100; i++)
            {
                var contact = ContactGenerator.Instance.GenerateContact();
                mOutput.WriteLine($"{contact.SortName} --- {contact.LongName} ---- {contact.GivenName}  ---- {contact.FamilyName} ----- {contact.Email} ---- {contact.TelephoneNumber}");
                contact.ShouldNotBeNull();
            }
        }

        [Fact]
        public void ContactGeneratorContact02()
        {
            List<string> eMails = new();
            for (int i = 0; i < 40; i++)
            {
                var contact = ContactGenerator.Instance.GenerateContact();

                contact.ShouldNotBeNull();
                eMails.ShouldNotContain(contact.Email);
                Assert.DoesNotContain(contact.Email, eMails);

                contact.Email.ShouldNotBeNullOrEmpty();

                eMails.Add(contact.Email);
                mOutput.WriteLine($"{contact.SortName} --- {contact.LongName} ---- {contact.GivenName}  ---- {contact.FamilyName} ----- {contact.Email} ---- {contact.TelephoneNumber}");
            }
        }

        [Fact]
        public void ContactGeneratorExtenderContactTest()
        {
            List<string> eMails = new();
            for (int i = 0; i < 1000; i++)
            {
                var contact = ContactGenerator.Instance.GenerateExtenderContact();

                contact.ShouldNotBeNull();
                eMails.ShouldNotContain(contact.Email);
                Assert.DoesNotContain(contact.Email, eMails);

                eMails.Add(contact.Email!);
                mOutput.WriteLine($"{contact.SortName} --- {contact.LongName} ---- {contact.GivenName}  ---- {contact.FamilyName} ----- {contact.Email} ---- {contact.TelephoneNumber}");
            }
        }
    }
}
