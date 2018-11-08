namespace Nivaes.DataTestGenerator.UnitTest.Tests
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using Xunit;

    [Collection("TaxIdGenerator")]
    public class TaxIdGeneratorTest
    {
        [Fact]
        public void CreateNifTest()
        {
            for (int i = 0; i < 10; i++)
            {
                string cif = TaxIdGenerator.GenerateNif();
                Debug.Print(cif);
            }
        }


        [Fact]
        public void CreateNieTest()
        {
            for (int i = 0; i < 10; i++)
            {
                string cif = TaxIdGenerator.GenerateNie();
                Debug.Print(cif);
            }
        }

        [Fact]
        public void CreateNifNieTest()
        {
            for (int i = 0; i < 10; i++)
            {
                string cif = TaxIdGenerator.GenerateNif();
                Debug.Print(cif);
            }
        }

        [Fact]
        public void CreateCifTest()
        {
            for (int i = 0; i < 10; i++)
            {
                string cif = TaxIdGenerator.GenerateCif();
                Debug.Print(cif);
            }
        }

        [Fact]
        public void GenerateTaxIdTest()
        {
            for (int i = 0; i < 10; i++)
            {
                string taxId = TaxIdGenerator.GenerateTaxId();
                Debug.Print(taxId);
            }
        }

        [Fact]
        public void TaxIdRepeatTest()
        {
            List<string> taxtIds = new List<string>();
            for (int i = 0; i < 1000; i++)
            {
                string taxId = TaxIdGenerator.GenerateTaxId();

                Assert.DoesNotContain(taxId, taxtIds);

                taxtIds.Add(taxId);
            }
        }
    }
}
