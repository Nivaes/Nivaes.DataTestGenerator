namespace Nivaes.DataTestGenerator
{
    using System;
    using System.Globalization;

    public static class CreateTaxId
    {
        #region Propeties
        /// <summary>Reference to <see cref="Random"/>.</summary>
        private static Random mRandom;
        #endregion

        #region Constructor
        /// <summary>Create a new instance of <see cref="CreateTaxId"/>.</summary>
        static CreateTaxId()
        {
            mRandom = new Random(DateTime.Now.Millisecond);
        }
        #endregion

        #region Methods
        /// <summary>Genera un NIF.</summary>
        public static string GenerateNif()
        {
            int num = mRandom.Next(1000, 100000000);
            return num.ToString("00000000", CultureInfo.InvariantCulture) + LetraNif(num);
        }

        /// <summary>Genera un NIF.</summary>
        public static string GenerateNie()
        {
            int num = mRandom.Next(1000, 100000000);
            return LetraNie() + num.ToString("00000000", CultureInfo.InvariantCulture) + LetraNif(num);
        }

        /// <summary>Cálculo de la letra del NIF.</summary> 
        private static string LetraNif(int nif)
        {
            return "TRWAGMYFPDXBNJZSQVHLCKET"[nif % 23].ToString();
        }

        /// <summary>Obtiene una letra aleatoria para el Nie.</summary>
        private static char LetraNie()
        {
            string nie = "XYZ";
            return nie[mRandom.Next(0, 3)];
        }

        //http://utilidesarrollo.blogspot.com.es/2010/11/generadores-de-documentos-dni-nie-y-cif.html

        /// <summary>Genera un CIF.</summary>
        public static string GenerateCif()
        {
            int num = mRandom.Next(1000, 10000000);
            string sNumbers = num.ToString("0000000", CultureInfo.InvariantCulture);

            int control = 10 - (ProcessedNumberOddPosition(sNumbers[0]) +
                        ProcessedNumberOddPosition(sNumbers[2]) +
                        ProcessedNumberOddPosition(sNumbers[4]) +
                        ProcessedNumberOddPosition(sNumbers[6]) +
                        int.Parse(sNumbers[1].ToString(), CultureInfo.InvariantCulture) +
                        int.Parse(sNumbers[3].ToString(), CultureInfo.InvariantCulture) +
                        int.Parse(sNumbers[5].ToString(), CultureInfo.InvariantCulture)) % 10;

            return "ABCDEFGHJKLMNPQRSUVW"[control - 1].ToString() + sNumbers + "ABCDEFGHIJ"[control - 1].ToString();
        }

        private static int ProcessedNumberOddPosition(char numberChar)
        {
            int number = int.Parse(numberChar.ToString(), CultureInfo.InvariantCulture);
            int sum = (2 * number) % 10;
            if (number >= 5)
                sum += 1;
            return sum;
        }

        /// <summary>Genera un TaxId.</summary>
        public static string GenerateTaxId()
        {
            int num = mRandom.Next(0, 10);
            if (num < 6)
                return GenerateCif();
            else if (num == 6)
                return GenerateNie();
            else
                return GenerateNif();

        }
        #endregion
    }
}
