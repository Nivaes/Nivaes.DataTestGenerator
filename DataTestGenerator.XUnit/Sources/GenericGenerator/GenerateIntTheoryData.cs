namespace Nivaes.DataTestGenerator.Xunit
{
    public sealed class GenerateIntTheoryData
        : TheoryData<int>
    {
        public GenerateIntTheoryData()
        {
            base.Add(GenericGenerator.GenerateInt());
        }

        public GenerateIntTheoryData(int dataNumber)
        {
            for (int i = 0; i < dataNumber; i++)
            {
                base.Add(GenericGenerator.GenerateInt());
            }
        }

        public GenerateIntTheoryData(int dataNumber, int maxSize, int minSize)
        {
            for (int i = 0; i < dataNumber; i++)
            {
                base.Add(GenericGenerator.GenerateInt(maxSize, minSize));
            }
        }
    }
}
