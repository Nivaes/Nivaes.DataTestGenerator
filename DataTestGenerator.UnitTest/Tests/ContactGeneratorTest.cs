namespace Nivaes.DataTestGenerator.UnitTest.Tests
{
    using System.Collections.Generic;
    using FluentAssertions;
    using global::Xunit;
    using global::Xunit.Abstractions;
    using Nivaes.DataTestGenerator.Xunit;

    public class ContactGeneratorTest
    {
        private readonly ITestOutputHelper mOutput;

        public ContactGeneratorTest(ITestOutputHelper output)
        {
            mOutput = output;
        }

        [Fact]
        public void  ContactGeneratorName()
        {
            for (int i = 0; i < 10; i++)
            {
                var name = ContactGenerator.Instance.GenerateName();
                mOutput.WriteLine(name);
                name.Should().NotBeNullOrEmpty();
            }
        }

        [Fact]
        public void ContactGeneratorContact01()
        {
            for (int i = 0; i < 100; i++)
            {
                var contact = ContactGenerator.Instance.GenerateContact();
                mOutput.WriteLine($"{contact.SortName} --- {contact.LongName} ---- {contact.PersonalName}  ---- {contact.FamilyName} ----- {contact.Email} ---- {contact.TelephoneNumber}");
                contact.Should().NotBeNull();
            }
        }

        [Fact]
        public void ContactGeneratorContact02()
        {
            List<string> eMails = new List<string>();
            for (int i = 0; i < 50; i++)
            {
                var contact = ContactGenerator.Instance.GenerateContact();

                contact.Should().NotBeNull();
                eMails.Should().NotContain(contact.Email);
                Assert.DoesNotContain(contact.Email, eMails);

                eMails.Add(contact.Email);
                mOutput.WriteLine($"{contact.SortName} --- {contact.LongName} ---- {contact.PersonalName}  ---- {contact.FamilyName} ----- {contact.Email} ---- {contact.TelephoneNumber}");
            }
        }

        [Fact]
        public void ContactGeneratorExtenderContactTest()
        {
            List<string> eMails = new List<string>();
            for (int i = 0; i < 1000; i++)
            {
                var contact = ContactGenerator.Instance.GenerateExtenderContact();

                contact.Should().NotBeNull();
                eMails.Should().NotContain(contact.Email);
                Assert.DoesNotContain(contact.Email, eMails);

                eMails.Add(contact.Email);
                mOutput.WriteLine($"{contact.SortName} --- {contact.LongName} ---- {contact.PersonalName}  ---- {contact.FamilyName} ----- {contact.Email} ---- {contact.TelephoneNumber}");
            }
        }

        [RetryFact(MaxRetries = 5, TimeSleep = 10)]
        public void ContactGeneratorExtenderContactRetryTest()
        {
            List<string> eMails = new List<string>();
            for (int i = 0; i < 3000; i++)
            {
                var contact = ContactGenerator.Instance.GenerateExtenderContact();

                contact.Should().NotBeNull();
                eMails.Should().NotContain(contact.Email);
                Assert.DoesNotContain(contact.Email, eMails);

                eMails.Add(contact.Email);
                mOutput.WriteLine($"{contact.SortName} --- {contact.LongName} ---- {contact.PersonalName}  ---- {contact.FamilyName} ----- {contact.Email} ---- {contact.TelephoneNumber}");
            }
        }
    }
}
