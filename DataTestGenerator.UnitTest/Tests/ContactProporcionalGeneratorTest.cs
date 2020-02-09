namespace Nivaes.DataTestGenerator.UnitTest
{
    using global::Xunit;
    using global::Xunit.Abstractions;

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
                mOutput.WriteLine(name);
            }
        }

        [Fact]
        public void ContactProporcionalGeneratorTest02()
        {
            for (int i = 0; i < 100; i++)
            {
                var contact = ContactProporcionalGenerator.Instance.GenerateContact();
                mOutput.WriteLine($"{contact.SortName} --- {contact.LongName} ---- {contact.PersonalName}  ---- {contact.FamilyName} ----- {contact.Email} ---- {contact.TelephoneNumber}");
            }
        }
    }
}
