namespace Nivaes.DataTestGenerator.UnitTest
{
    public class ContactGeneratorTest
    {
        private readonly ITestOutputHelper _output;

        public ContactGeneratorTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void ContactGeneratorName()
        {
            for (int i = 0; i < 10; i++)
            {
                var name = ContactGenerator.GenerateName();
                _output.WriteLine(name);
                name.ShouldNotBeNullOrEmpty();
            }
        }

        [Fact]
        public void ContactGeneratorContact01()
        {
            for (int i = 0; i < 100; i++)
            {
                var contact = ContactGenerator.GenerateContact();
                _output.WriteLine($"{contact.SortName} --- {contact.LongName} ---- {contact.GivenName}  ---- {contact.FamilyName} ----- {contact.Email} ---- {contact.TelephoneNumber}");
                contact.ShouldNotBeNull();
            }
        }

        [Fact]
        public void ContactGeneratorContact02()
        {
            List<string> longNames = new();
            for (int i = 0; i < 400; i++)
            {
                var contact = ContactGenerator.GenerateContact();

                contact.ShouldNotBeNull();

                contact.LongName.ShouldNotBeNullOrEmpty();
                contact.SortName.ShouldNotBeNullOrEmpty();
                contact.Email.ShouldNotBeNullOrEmpty();

                contact.ShouldNotBeNull();
                longNames.ShouldNotContain(contact.LongName);

                longNames.Add(contact.LongName);
                _output.WriteLine($"{contact.SortName} --- {contact.LongName} ---- {contact.GivenName}  ---- {contact.FamilyName} ----- {contact.Email} ---- {contact.TelephoneNumber}");
            }
        }

        [Fact]
        public void ContactGeneratorExtenderContactTest()
        {
            List<string> eMails = new();
            for (int i = 0; i < 1000; i++)
            {
                var contact = ContactGenerator.GenerateExtenderContact();

                contact.ShouldNotBeNull();
                eMails.ShouldNotContain(contact.Email);
                Assert.DoesNotContain(contact.Email, eMails);

                eMails.Add(contact.Email!);
                _output.WriteLine($"{contact.SortName} --- {contact.LongName} ---- {contact.GivenName}  ---- {contact.FamilyName} ----- {contact.Email} ---- {contact.TelephoneNumber}");
            }
        }
    }
}
