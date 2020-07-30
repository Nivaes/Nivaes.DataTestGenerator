namespace Nivaes.DataTestGenerator.Xunit
{
    using global::Xunit;

    public sealed class GenerateContactTheoryData
        : TheoryData<string>
    {
        public GenerateContactTheoryData()
        {
            base.Add(PasswordGenerator.Instance.GeneratePassword());
        }

        public GenerateContactTheoryData(int dataNumber)
        {
            for (int i = 0; i < dataNumber; i++)
            {
                base.Add(PasswordGenerator.Instance.GeneratePassword());
            }
        }

        public GenerateContactTheoryData(int dataNumber, int length)
        {
            for (int i = 0; i < dataNumber; i++)
            {
                base.Add(PasswordGenerator.Instance.GeneratePassword(length));
            }
        }

        public GenerateContactTheoryData(int dataNumber, string characterSet)
        {
            for (int i = 0; i < dataNumber; i++)
            {
                base.Add(PasswordGenerator.Instance.GeneratePassword(characterSet));
            }
        }

        public GenerateContactTheoryData(int dataNumber, int length, string characterSet)
        {
            for (int i = 0; i < dataNumber; i++)
            {
                base.Add(PasswordGenerator.Instance.GeneratePassword(length, characterSet));
            }
        }
    }
}
