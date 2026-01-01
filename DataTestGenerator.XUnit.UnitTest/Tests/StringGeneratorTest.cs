using Xunit;

namespace Nivaes.DataTestGenerator.Xunit.UnitTest
{
    using Shouldly;

    public class StringGeneratorTest
    {
        private readonly ITestOutputHelper mOutput;

        public static readonly GenerateStringTheoryData PasswordsMatrixData = new GenerateStringTheoryData();

        public StringGeneratorTest(ITestOutputHelper output)
        {
            mOutput = output;
        }

        [Theory]
        [InlineData("text")]
        public void String_generate_inline(string password)
        {
            mOutput.WriteLine(password);
            password.ShouldNotBeNullOrEmpty();
        }

        [Theory]
        [ClassData(typeof(GenerateStringTheoryData))]
        public void StringGenerateTeoryData(string password)
        {
            mOutput.WriteLine(password);
            password.ShouldNotBeNullOrEmpty();
        }

        [Theory]
        [MemberData(nameof(PasswordsMatrixData))]
        public void StringGenerateMemberData(string password)
        {
            mOutput.WriteLine(password);
            password.ShouldNotBeNullOrEmpty();
        }

        [Theory]
        [GenerateStringInlineData(DataNumber = 3)]
        public void StringGenerateStringInline(string password)
        {
            mOutput.WriteLine(password);
            password.ShouldNotBeNullOrEmpty();
        }

        [Theory]
        [InlineData("password")]
        [ClassData(typeof(GenerateStringTheoryData))]
        [MemberData(nameof(PasswordsMatrixData))]
        [GenerateStringInlineData(DataNumber = 3)]
        public void StringGenerateAll(string password)
        {
            mOutput.WriteLine(password);
            password.ShouldNotBeNullOrEmpty();
        }
    }
}
