namespace Nivaes.DataTestGenerator.UnitTest.Tests
{
    using System.Diagnostics;
    using Xunit;
    using FluentAssertions;

    public class TestGenericGeneratorTest
    {
        [Fact]
        public void TestGenericGeneratorString()
        {
            for (int i = 0; i < 10; i++)
            {
                var strGenerate = TestGenericGenerator.Instance.GenerateString();
                Debug.Print(strGenerate);
                strGenerate.Should().NotBeNullOrEmpty();
            }
        }

        [Fact]
        public void TestGenericGeneratorStringSize()
        {
            for (int i = 1000; i < 1100; i++)
            {
                var strGenerate = TestGenericGenerator.Instance.GenerateString(i);
                Debug.Print(strGenerate);
                strGenerate.Should().NotBeNullOrEmpty();
                strGenerate.Length.Should().Be(i);
            }
        }

        [Fact]
        public void TestGenericGeneratorStringIntervalSize()
        {
            for (int i = 1100; i < 1200; i++)
            {
                for (int j = 1200; j < i + 1300; j++)
                {
                    var strGenerate = TestGenericGenerator.Instance.GenerateString(i, j);
                    Debug.Print(strGenerate);
                    strGenerate.Should().NotBeNullOrEmpty();
                    strGenerate.Length.Should().BeGreaterOrEqualTo(i);
                    strGenerate.Length.Should().BeLessOrEqualTo(j);
                }
            }
        }

        [Fact]
        public void TestGenericGeneratorIntSize()
        {
            for (int i = 0; i < 10; i++)
            {
                var intGenerate = TestGenericGenerator.Instance.GenerateInt();
                intGenerate.Should().BeLessOrEqualTo(int.MaxValue);
                intGenerate.Should().BeGreaterOrEqualTo(int.MinValue);
            }
        }

        [Fact]
        public void TestGenericGeneratorSize()
        {
            for (int i = 1000; i < 100000; i++)
            {
                var intGenerate = TestGenericGenerator.Instance.GenerateInt(i);
                intGenerate.Should().BeLessOrEqualTo(i);
            }
        }

        [Fact]
        public void TestGenericGeneratorIntervalSize()
        {
            for (int i = 100; i < 1000; i++)
            {
                for (int j = 1000; j < 1500; j++)
                {
                    var intGenerate = TestGenericGenerator.Instance.GenerateInt(i, j);
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
                    var doubleGenerate = TestGenericGenerator.Instance.GenerateDouble(i, j);
                    doubleGenerate.Should().BeInRange(i, j);
                }
            }
        }
    }
}
