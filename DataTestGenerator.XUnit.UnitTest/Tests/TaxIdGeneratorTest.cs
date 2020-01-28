namespace Nivaes.DataTestGenerator.Xunit.UnitTest
{
    using System.Collections.Generic;
    using FluentAssertions;
    using global::Xunit;
    using global::Xunit.Abstractions;
    using Nivaes.DataTestGenerator.Xunit;

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
        [RetryInlineData(4000, MaxRetries = 3)]
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
        [RetryInlineData(1000)]
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
    }
}
