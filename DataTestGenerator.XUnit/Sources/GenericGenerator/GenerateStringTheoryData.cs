using Xunit;

namespace Nivaes.DataTestGenerator.Xunit
{
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

        public GenerateStringTheoryData(int dataNumber, int minSize, int maxSize)
        {
            for (int i = 0; i < dataNumber; i++)
            {
                base.Add(GenericGenerator.Instance.GenerateString(minSize, maxSize));
            }
        }
    }
}
