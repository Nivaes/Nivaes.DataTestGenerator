namespace Nivaes.DataTestGenerator.UnitTest.Tests
{
    using System.Collections.Generic;
    using FluentAssertions;
    using Xunit;

    public class TaxIdGeneratorTest
    {
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

                taxtIds.Should().NotContain(taxId, "Repetido en {0} interacciones.", i);

                taxtIds.Add(taxId);
            }
        }
    }
}
