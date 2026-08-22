namespace Nivaes.DataTestGenerator.Xunit.UnitTest
{
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
        public void StringGenerateInline(string password)
        {
            mOutput.WriteLine($"{nameof(StringGenerateInline)}: {password}");
            password.ShouldNotBeNullOrEmpty();
        }

        [Theory]
        [ClassData(typeof(GenerateStringTheoryData))]
        public void StringGenerateTheoryData(string password)
        {
            mOutput.WriteLine($"{nameof(StringGenerateTheoryData)}: {password}");
            password.ShouldNotBeNullOrEmpty();
        }

        [Theory]
        [MemberData(nameof(PasswordsMatrixData))]
        public void StringGenerateMemberData(string password)
        {
            mOutput.WriteLine($"{nameof(StringGenerateMemberData)}: {password}");
            password.ShouldNotBeNullOrEmpty();
        }

        [Theory]
        [GenerateStringInlineData(DataNumber = 3)]
        public void StringGenerateStringInline(string password)
        {
            mOutput.WriteLine($"{nameof(StringGenerateStringInline)}: {password}");
            password.ShouldNotBeNullOrEmpty();
        }

        [Theory]
        [InlineData("password")]
        [ClassData(typeof(GenerateStringTheoryData))]
        [MemberData(nameof(PasswordsMatrixData))]
        [GenerateStringInlineData(DataNumber = 3)]
        public void StringGenerateAll(string password)
        {
            mOutput.WriteLine($"{nameof(StringGenerateAll)}: {password}");
            password.ShouldNotBeNullOrEmpty();
        }
    }
}
