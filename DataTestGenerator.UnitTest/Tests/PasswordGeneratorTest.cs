namespace Nivaes.DataTestGenerator.UnitTest.Tests
{
    using FluentAssertions;
    using global::Xunit;
    using global::Xunit.Abstractions;
    using Nivaes.DataTestGenerator.Xunit;
    using System.Collections.Generic;

    public class PasswordGeneratorTest
    {
        private readonly ITestOutputHelper mOutput;

        public static GeneratePasswordTheoryData PasswordsMatrixData = new GeneratePasswordTheoryData(10, 20);

        public PasswordGeneratorTest(ITestOutputHelper output)
        {
            mOutput = output;
        }

        [Fact]
        public void PasswordGeneratorString01()
        {
            var password = PasswordGenerator.Instance.CreatePassword();
            mOutput.WriteLine(password);
            password.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void PasswordGeneratorString02()
        {
            List<string> passwords = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                var password = PasswordGenerator.Instance.CreatePassword();

                password.Should().NotBeNullOrEmpty();
                passwords.Should().NotContain(password);

                passwords.Add(password);
                mOutput.WriteLine(password);
            }
        }

        [Theory]
        [InlineData("ddefff")]
        [MemberData(nameof(PasswordsMatrixData))]
        [GeneratePasswordInlineData(DataNumber = 3)]
        public void PasswordGenerator03(string password)
        {
            mOutput.WriteLine(password);
            password.Should().NotBeNullOrEmpty();
        }
    }
}
