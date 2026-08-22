namespace Nivaes.DataTestGenerator.Xunit
{
    public sealed class GenerateDoubleTheoryData
        : TheoryData<double>
    {
        public GenerateDoubleTheoryData(int dataNumber, double minSize, double maxSize)
        {
            for (int i = 0; i < dataNumber; i++)
            {
                base.Add(GenericGenerator.GenerateDouble(minSize, maxSize));
            }
        }
    }
}
