﻿using Xunit;
using Xunit.Abstractions;

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

        [RetryFact(MaxRetries = 5, TimeSleep = 10)]
        public void ContactGeneratorExtenderContactRetryTest()
        {
            List<string> eMails = new();
            for (int i = 0; i < 10000; i++)
            {
                var contact = ContactGenerator.Instance.GenerateExtenderContact();

                contact.Should().NotBeNull();
                eMails.Should().NotContain(contact.Email);
                Assert.DoesNotContain(contact.Email, eMails);
                eMails.Add(contact.Email!);
                mOutput.WriteLine($"{contact.SortName} --- {contact.LongName} ---- {contact.PersonalName}  ---- {contact.FamilyName} ----- {contact.Email} ---- {contact.TelephoneNumber}");
            }
        }

        [Theory]
        [GenerateContactInlineData(DataNumber = 3)]
        public void ContactGeneratorExtenderContactTest(ContactTest contact)
        {
            contact.Should().NotBeNull();
            mOutput.WriteLine($"{contact?.SortName} --- {contact?.LongName} ---- {contact?.PersonalName}  ---- {contact?.FamilyName} ----- {contact?.Email} ---- {contact?.TelephoneNumber}");
        }
    }
}
