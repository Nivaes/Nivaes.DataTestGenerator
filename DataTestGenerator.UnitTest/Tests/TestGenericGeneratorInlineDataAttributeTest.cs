namespace Nivaes.DataTestGenerator.UnitTest.Tests
{
    using FluentAssertions;
    using Xunit;
    using Xunit.Abstractions;

    public class TestGenericGeneratorInlineDataAttributeTest
    {
        private readonly ITestOutputHelper mOutput;

        public static GenerateStringTheoryData StringMatrixData = new GenerateStringTheoryData(10, 20, 50);
        public static GenerateIntTheoryData IntMatrixData = new GenerateIntTheoryData(10, 100, 10000);
        public static GenerateDoubleTheoryData DoubleMatrixData = new GenerateDoubleTheoryData(10, -23551.2213, 12553.32158);

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
            value.Should().BeGreaterOrEqualTo(100);
            value.Should().BeLessOrEqualTo(10000);
        }

        [Fact]
        public void TestGenericGeneratorDoubleInterval()
        {
            for (double i = -23551.2213; i < 12553.32158; i += 1425.32)
            {
                for (double j = 12653.32158; j < 12533453.32158; j += 25783.35)
                {
                    var doubleGenerate = TestGenericGenerator.Instance.GenerateDouble(i, j);
                    doubleGenerate.Should().BeInRange(i, j);
                }
            }
        }

        [Theory]
        [InlineData(525)]
        [MemberData(nameof(IntMatrixData))]
        [GenerateDoubleInlineData(3, -23551.2213, 12553.32158)]
        public void TestGenericGeneratorDouble(double value)
        {
            mOutput.WriteLine($"{value}");
            value.Should().BeGreaterOrEqualTo(-23551.2213);
            value.Should().BeLessOrEqualTo(12553.32158);
        }
    }
}
