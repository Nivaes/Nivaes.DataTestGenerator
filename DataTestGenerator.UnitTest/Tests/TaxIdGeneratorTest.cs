namespace Nivaes.DataTestGenerator.UnitTest
{
    using System.Collections.Generic;
    using FluentAssertions;
    using global::Xunit;
    using global::Xunit.Abstractions;

    public class TaxIdGeneratorTest
    {
        private readonly ITestOutputHelper mOutput;

        public TaxIdGeneratorTest(ITestOutputHelper output)
        {
            mOutput = output;
        }

        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(300)]
        public void CreateNifTest(int n)
        {
            List<string> taxtIds = new();
            for (int i = 0; i < n; i++)
            {
                string taxId = TaxIdGenerator.GenerateNif();

                mOutput.WriteLine(taxId);

                taxtIds.Should().NotContain(taxId, "Repetido en {0} interacciones.", i);

                taxtIds.Add(taxId);
            }
        }

        [Theory]
        [InlineData(10)]
        [InlineData(1000)]
        [InlineData(2000)]
        public void CreateNifNieTest(int n)
        {
            List<string> taxtIds = new();
            for (int i = 0; i < n; i++)
            {
                string taxId = TaxIdGenerator.GenerateNifNie();

                mOutput.WriteLine(taxId);

                taxtIds.Should().NotContain(taxId, "Repetido en {0} interacciones.", i);

                taxtIds.Add(taxId);
            }
        }

        [Theory]
        [InlineData(10)]
        [InlineData(1000)]
        [InlineData(2000)]
        public void TaxIdTest(int n)
        {
            List<string> taxtIds = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string taxId = TaxIdGenerator.GenerateTaxId();

                mOutput.WriteLine(taxId);

                taxtIds.Should().NotContain(taxId, "Repetido en {0} interacciones.", i);

                taxtIds.Add(taxId);
            }
        }
    }
}
