namespace Nivaes.DataTestGenerator.UnitTest
{
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
                name.ShouldNotBeNullOrWhiteSpace();
                mOutput.WriteLine(name);
            }
        }

        [Fact]
        public void ContactProporcionalGeneratorTest02()
        {
            for (int i = 0; i < 100; i++)
            {
                var contact = ContactProporcionalGenerator.Instance.GenerateContact();
                contact.ShouldNotBeNull();
                contact.GivenName.ShouldNotBeNullOrWhiteSpace();
                contact.FamilyName.ShouldNotBeNullOrWhiteSpace();
                contact.LongName.ShouldNotBeNullOrWhiteSpace();
                contact.SortName.ShouldNotBeNullOrWhiteSpace();
                contact.Email.ShouldNotBeNullOrWhiteSpace();
                contact.TelephoneNumber.ShouldNotBeNullOrWhiteSpace();
                mOutput.WriteLine($"{contact.SortName} --- {contact.LongName} ---- {contact.GivenName}  ---- {contact.FamilyName} ----- {contact.Email} ---- {contact.TelephoneNumber}");
            }
        }
    }
}
