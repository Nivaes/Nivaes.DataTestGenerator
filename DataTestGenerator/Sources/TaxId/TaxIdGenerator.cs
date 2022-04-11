namespace Nivaes.DataTestGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public static class TaxIdGenerator
    {
        #region Random number
        /// <summary>Reference to <see cref="System.Random"/>.</summary>
        private static readonly Random Random = new Random(DateTime.Now.Millisecond);

        /// <summary>Set of generate numbers.</summary>
        private static readonly HashSet<int> GenerateNumbers = new HashSet<int>();

        /// <summary>Generate a randon number</summary>
        private static int RandonNumber()
        {
            int num;
            do
            {
                num = Random.Next(1000, 99999999);
            } while (GenerateNumbers.Contains(num));

            GenerateNumbers.Add(num);
            return num;

        }
        #endregion

        #region Methods
        /// <summary>Genera un NIF.</summary>
        public static string GenerateNif()
        {
            int num = RandonNumber();
            return num.ToString("00000000", CultureInfo.InvariantCulture) + LetraNif(num);
        }

        /// <summary>Genera un NIF.</summary>
        public static string GenerateNie()
        {
            int num = RandonNumber();
            return LetraNie() + num.ToString("00000000", CultureInfo.InvariantCulture) + LetraNif(num);
        }

        /// <summary>Genera un NIF o NIE.</summary>
        public static string GenerateNifNie()
        {
            if(Random.Next(0, 4) == 0)
            {
                return GenerateNie();
            }
            else
            {
                return GenerateNif();
            }
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
            return nie[Random.Next(0, 3)];
        }

        //http://utilidesarrollo.blogspot.com.es/2010/11/generadores-de-documentos-dni-nie-y-cif.html

        /// <summary>Genera un CIF.</summary>
        public static string GenerateCif()
        {
            int num = RandonNumber();
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
            int num = Random.Next(0, 10);
            if (num < 2)
                return GenerateCif();
            else if (num < 5)
                return GenerateNie();
            else
                return GenerateNif();

        }
        #endregion
    }
}
