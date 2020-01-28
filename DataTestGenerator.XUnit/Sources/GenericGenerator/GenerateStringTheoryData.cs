namespace Nivaes.DataTestGenerator.Xunit
{
    using global::Xunit;

    public sealed class GenerateStringTheoryData
        : TheoryData<string>
    {
        public GenerateStringTheoryData()
        {
            base.Add(GenericGenerator.Instance.GenerateString());
        }

        public GenerateStringTheoryData(int dataNumber)
        {
            for (int i = 0; i < dataNumber; i++)
            {
                base.Add(GenericGenerator.Instance.GenerateString());
            }
        }

        public GenerateStringTheoryData(int dataNumber, int maxSize, int minSize)
        {
            for (int i = 0; i < dataNumber; i++)
            {
                base.Add(GenericGenerator.Instance.GenerateString(maxSize, minSize));
            }
        }
    }
}
