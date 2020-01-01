namespace Nivaes.DataTestGenerator.UnitTest.Tests
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
        [InlineData(1000)]
        [InlineData(3000)]
        public void CreateNifTest(int n)
        {
            List<string> taxtIds = new List<string>();
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
        [InlineData(4000)]
        public void CreateNieTest(int n)
        {
            List<string> taxtIds = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string taxId = TaxIdGenerator.GenerateNie();

                mOutput.WriteLine(taxId);

                taxtIds.Should().NotContain(taxId, "Repetido en {0} interacciones.", i);

                taxtIds.Add(taxId);
            }
        }

        [Theory]
        [InlineData(10)]
        [InlineData(1000)]
        [InlineData(4000)]
        public void CreateNifNieTest(int n)
        {
            List<string> taxtIds = new List<string>();
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
        public void CreateCifTest(int n)
        {
            List<string> taxtIds = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string taxId = TaxIdGenerator.GenerateCif();

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
