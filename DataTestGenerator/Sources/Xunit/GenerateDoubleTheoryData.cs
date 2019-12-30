namespace Nivaes.DataTestGenerator
{
    using Xunit;

    public sealed class GenerateDoubleTheoryData : TheoryData<double>
    {
        public GenerateDoubleTheoryData(int dataNumber, double maxSize, double minSize)
        {
            for (int i = 0; i < dataNumber; i++)
            {
                base.Add(GenericGenerator.Instance.GenerateDouble(maxSize, minSize));
            }
        }
    }
}
