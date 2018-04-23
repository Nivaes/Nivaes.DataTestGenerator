namespace Nivaes.DataTestGenerator.UnitTest.Tests
{
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
                string cif = TaxIdGenerator.GenerateTaxId();
                Debug.Print(cif);
            }
        }
    }
}
