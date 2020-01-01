namespace Nivaes.DataTestGenerator.UnitTest.Tests
{
    using FluentAssertions;
    using global::Xunit;
    using global::Xunit.Abstractions;

    public class GenericGeneratorTest
    {
        private readonly ITestOutputHelper mOutput;

        public GenericGeneratorTest(ITestOutputHelper output)
        {
            mOutput = output;
        }

        [Fact]
        public void GenericGeneratorString()
        {
            for (int i = 0; i < 10; i++)
            {
                var strGenerate = GenericGenerator.Instance.GenerateString();
                mOutput.WriteLine(strGenerate);
                strGenerate.Should().NotBeNullOrEmpty();
            }
        }

        [Fact]
        public void GenericGeneratorStringSize()
        {
            for (int i = 1000; i < 1100; i++)
            {
                var strGenerate = GenericGenerator.Instance.GenerateString(i);
                strGenerate.Should().NotBeNullOrEmpty();
                strGenerate.Length.Should().Be(i);
            }
        }

        [Fact]
        public void GenericGeneratorStringIntervalSize()
        {
            for (int i = 1100; i < 1200; i++)
            {
                for (int j = 1200; j < i + 1300; j++)
                {
                    var strGenerate = GenericGenerator.Instance.GenerateString(i, j);
                    strGenerate.Should().NotBeNullOrEmpty();
                    strGenerate.Length.Should().BeGreaterOrEqualTo(i);
                    strGenerate.Length.Should().BeLessOrEqualTo(j);
                }
            }
        }

        [Fact]
        public void GenericGeneratorIntSize()
        {
            for (int i = 0; i < 10; i++)
            {
                var intGenerate = GenericGenerator.Instance.GenerateInt();
                mOutput.WriteLine($"{intGenerate}");
                intGenerate.Should().BeLessOrEqualTo(int.MaxValue);
                intGenerate.Should().BeGreaterOrEqualTo(int.MinValue);
            }
        }

        [Fact]
        public void GenericGeneratorSize()
        {
            for (int i = 1000; i < 100000; i++)
            {
                var intGenerate = GenericGenerator.Instance.GenerateInt(i);
                mOutput.WriteLine($"{intGenerate}");
                intGenerate.Should().BeLessOrEqualTo(i);
            }
        }

        [Fact]
        public void GenericGeneratorIntervalSize()
        {
            for (int i = 100; i < 1000; i++)
            {
                for (int j = 1000; j < 1500; j++)
                {
                    var intGenerate = GenericGenerator.Instance.GenerateInt(i, j);
                    mOutput.WriteLine($"{intGenerate}");
                    intGenerate.Should().BeGreaterOrEqualTo(i);
                    intGenerate.Should().BeLessOrEqualTo(j);
                }
            }
        }

        [Fact]
        public void TestGenericGeneratorDoubleInterval()
        {
            for (double i = -23551.2213; i < 12553.32158; i += 1425.32)
            {
                for (double j = 12653.32158; j < 12533453.32158; j += 25783.35)
                {
                    var doubleGenerate = GenericGenerator.Instance.GenerateDouble(i, j);
                    mOutput.WriteLine($"{doubleGenerate}");
                    doubleGenerate.Should().BeInRange(i, j);
                }
            }
        }
    }
}
