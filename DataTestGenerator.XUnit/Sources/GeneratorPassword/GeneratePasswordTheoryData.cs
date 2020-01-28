namespace Nivaes.DataTestGenerator.Xunit
{
    using global::Xunit;

    public sealed class GeneratePasswordTheoryData
        : TheoryData<string>
    {
        public GeneratePasswordTheoryData()
        {
            base.Add(PasswordGenerator.Instance.CreatePassword());
        }

        public GeneratePasswordTheoryData(int dataNumber)
        {
            for (int i = 0; i < dataNumber; i++)
            {
                base.Add(PasswordGenerator.Instance.CreatePassword());
            }
        }

        public GeneratePasswordTheoryData(int dataNumber, int length)
        {
            for (int i = 0; i < dataNumber; i++)
            {
                base.Add(PasswordGenerator.Instance.CreatePassword(length));
            }
        }

        public GeneratePasswordTheoryData(int dataNumber, string characterSet)
        {
            for (int i = 0; i < dataNumber; i++)
            {
                base.Add(PasswordGenerator.Instance.CreatePassword(characterSet));
            }
        }

        public GeneratePasswordTheoryData(int dataNumber, int length, string characterSet)
        {
            for (int i = 0; i < dataNumber; i++)
            {
                base.Add(PasswordGenerator.Instance.CreatePassword(length, characterSet));
            }
        }
    }
}
