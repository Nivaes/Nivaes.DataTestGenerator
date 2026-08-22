using System.Text;

namespace Nivaes.DataTestGenerator
{
    public static class GenericGenerator
    {
        public static string GenerateString()
        {
            var size = Random.Shared.Next(5000);
            return GenerateString(size);
        }

        public static string GenerateString(int size)
        {
            var buffer = new byte[size * 2];
            Random.Shared.NextBytes(buffer);

            return Encoding.Unicode.GetString(buffer);
        }

        public static string GenerateString(int minSize, int maxSize)
        {
            var size = Random.Shared.Next(minSize, maxSize);
            return GenerateString(size);
        }

        public static int GenerateInt() => Random.Shared.Next();

        public static int GenerateInt(int maxValue) => Random.Shared.Next(maxValue);

        public static int GenerateInt(int minValue, int maxValue) => Random.Shared.Next(minValue, maxValue);

        public static double GenerateDouble(double minValue, double maxValue)
        {
            var rando = Random.Shared.NextDouble();
            
            return rando * (maxValue - minValue) + minValue;
        }
    }
}
