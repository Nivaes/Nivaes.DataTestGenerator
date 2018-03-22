namespace Nivaes.DataTestGenerator.UnitTest.Tests
{
    using System.Diagnostics;
    using Xunit;

    [Collection("CreateTaxId")]
    public class CreateTaxIdTest
    {
        [Fact]
        public void CreateNifTest()
        {
            for (int i = 0; i < 10; i++)
            {
                string cif = CreateTaxId.GenerateNif();
                Debug.Print(cif);
            }
        }


        [Fact]
        public void CreateNieTest()
        {
            for (int i = 0; i < 10; i++)
            {
                string cif = CreateTaxId.GenerateNie();
                Debug.Print(cif);
            }
        }

        [Fact]
        public void CreateCifTest()
        {
            for (int i = 0; i < 10; i++)
            {
                string cif = CreateTaxId.GenerateCif();
                Debug.Print(cif);
            }
        }

        [Fact]
        public void GenerateTaxIdTest()
        {
            for (int i = 0; i < 10; i++)
            {
                string cif = CreateTaxId.GenerateTaxId();
                Debug.Print(cif);
            }
        }
    }
}
