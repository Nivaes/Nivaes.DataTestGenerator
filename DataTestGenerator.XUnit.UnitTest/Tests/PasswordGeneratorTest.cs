namespace Nivaes.DataTestGenerator.Xunit.UnitTest
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
