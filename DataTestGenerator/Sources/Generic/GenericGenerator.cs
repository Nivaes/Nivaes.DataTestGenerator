namespace Nivaes.DataTestGenerator
{
    using System;
    using System.Text;

    public sealed class GenericGenerator
    {
        /// <summary>Reference to <see cref="mRandom"/>.</summary>
        private Random mRandom { get; } = new Random(DateTime.Now.Second * DateTime.Now.Millisecond);

        private static GenericGenerator? mTestGenericGenerator;

        public static GenericGenerator Instance
        {
            get
            {
                if (mTestGenericGenerator == null)
                    mTestGenericGenerator = new GenericGenerator();

                return mTestGenericGenerator;
            }
        }

        public string GenerateString()
        {
            var size = mRandom.Next(5000);
            return GenerateString(size);
        }

        public string GenerateString(int size)
        {
            var buffer = new byte[size * 2];
            mRandom.NextBytes(buffer);

            return Encoding.Unicode.GetString(buffer);
        }

        public string GenerateString(int minSize, int maxSize)
        {
            var size = mRandom.Next(minSize, maxSize);
            return GenerateString(size);
        }

        public int GenerateInt() => mRandom.Next();

        public int GenerateInt(int maxValue) => mRandom.Next(maxValue);

        public int GenerateInt(int minValue, int maxValue) => mRandom.Next(minValue, maxValue);

        public double GenerateDouble(double minValue, double maxValue)
        {
            var rando = mRandom.NextDouble();
            
            return rando * (maxValue - minValue) + minValue;
        }
    }
}
