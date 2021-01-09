using Xunit;
using Xunit.Abstractions;

namespace Nivaes.DataTestGenerator.Xunit.UnitTest
{
    using FluentAssertions;

    public class PasswordGeneratorTest
    {
        private readonly ITestOutputHelper mOutput;

        public static readonly GenerateContactTheoryData PasswordsMatrixData = new GenerateContactTheoryData(10, 20);

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
