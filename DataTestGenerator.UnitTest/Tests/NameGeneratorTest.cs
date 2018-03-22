namespace Nivaes.DataTestGenerator.UnitTest.Tests
{
    using System.Diagnostics;
    using Xunit;

    [Collection("NameGenerator")]
    public class NameGeneratorTest
    {
        [Fact]
        public void  NameGeneratorTest01()
        {
            for (int i = 0; i < 10; i++)
            {
                NameGenerator.GenerateName(out string sortName, out string longName);
                Debug.Print(sortName + " --- " + longName);
            }
        }
    }
}
