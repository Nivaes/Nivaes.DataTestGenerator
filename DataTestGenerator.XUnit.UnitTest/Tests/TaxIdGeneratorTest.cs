namespace Nivaes.DataTestGenerator.Xunit.UnitTest
{
    using System.Collections.Generic;
    using Shouldly;

    public class TaxIdGeneratorTest
    {
        private readonly ITestOutputHelper mOutput;

        public TaxIdGeneratorTest(ITestOutputHelper output)
        {
            mOutput = output;
        }

        [Theory]
        [InlineData(10)]
        [InlineData(1000)]
        public void CreateNieTest(int n)
        {
            List<string> taxtIds = new();
            for (int i = 0; i < n; i++)
            {
                string taxId = TaxIdGenerator.GenerateNie();

                mOutput.WriteLine(taxId);

                taxtIds.ShouldNotContain(taxId, $"Repetido en {i} interacciones.");

                taxtIds.Add(taxId);
            }
        }

        [Theory]
        [InlineData(10)]
        public void CreateCifTest(int n)
        {
            List<string> taxtIds = new();
            for (int i = 0; i < n; i++)
            {
                string taxId = TaxIdGenerator.GenerateCif();

                mOutput.WriteLine(taxId);

                taxtIds.ShouldNotContain(taxId, $"Repetido en {i} interacciones.");

                taxtIds.Add(taxId);
            }
        }
    }
}
