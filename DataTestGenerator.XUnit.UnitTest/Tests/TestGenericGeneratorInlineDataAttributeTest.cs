using Xunit;
using Xunit.Abstractions;

namespace Nivaes.DataTestGenerator.Xunit.UnitTest
{
    using FluentAssertions;

    public class TestGenericGeneratorInlineDataAttributeTest
    {
        private readonly ITestOutputHelper mOutput;

        public static readonly GenerateStringTheoryData StringMatrixData = new GenerateStringTheoryData(10, 20, 50);
        public static readonly GenerateIntTheoryData IntMatrixData = new GenerateIntTheoryData(10, 100, 10000);
        public static readonly GenerateDoubleTheoryData DoubleMatrixData = new GenerateDoubleTheoryData(10, -23551.2213, 12553.32158);

        public TestGenericGeneratorInlineDataAttributeTest(ITestOutputHelper output)
        {
            mOutput = output;
        }

        [Theory]
        [InlineData("ddefff")]
        [MemberData(nameof(StringMatrixData))]
        [GenerateStringInlineData(DataNumber = 3, MinSize = 35, MaxSize = 66)]
        public void TestGenericGeneratorString(string value)
        {
            mOutput.WriteLine(value);
            value.Should().NotBeNullOrEmpty();
        }

        [Theory]
        [InlineData(525)]
        [MemberData(nameof(IntMatrixData))]
        [GenerateIntInlineData(DataNumber = 3, MinValue = 10, MaxValue = 10000)]
        public void TestGenericGeneratorInt(int value)
        {
            mOutput.WriteLine($"{value}");
            value.Should().BeGreaterOrEqualTo(10);
            value.Should().BeLessOrEqualTo(10000);
        }

        [Theory]
        [InlineData(525.0)]
        [MemberData(nameof(DoubleMatrixData))]
        [GenerateDoubleInlineData(3, -23551.2213, 12553.32158)]
        public void TestGenericGeneratorDouble(double value)
        {
            mOutput.WriteLine($"{value}");
            value.Should().BeGreaterOrEqualTo(-23551.2213);
            value.Should().BeLessOrEqualTo(12553.32158);
        }
    }
}
