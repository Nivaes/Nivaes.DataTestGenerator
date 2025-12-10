using Xunit;

namespace Nivaes.DataTestGenerator.Xunit.UnitTest
{
    using FluentAssertions;

    public class PasswordGeneratorTest
    {
        private readonly ITestOutputHelper mOutput;

        public static readonly GeneratePasswordTheoryData PasswordsMatrixData = new GeneratePasswordTheoryData(10, 20);

        public PasswordGeneratorTest(ITestOutputHelper output)
        {
            mOutput = output;
        }

        [Theory]
        [InlineData("password")]
        [ClassData(typeof(GeneratePasswordTheoryData))]
        [MemberData(nameof(PasswordsMatrixData))]
        [GeneratePasswordInlineData(DataNumber = 3)]
        public void PasswordGenerator03(string password)
        {
            mOutput.WriteLine(password);
            password.Should().NotBeNullOrEmpty();
        }
    }
}
