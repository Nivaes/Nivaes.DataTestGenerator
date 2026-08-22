namespace Nivaes.DataTestGenerator.Xunit
{
    public sealed class GenerateContactTheoryData
        : TheoryData<ContactTest>
    {
        public GenerateContactTheoryData()
        {
            base.Add(ContactGenerator.GenerateContact());
        }

        public GenerateContactTheoryData(int dataNumber)
        {
            for (int i = 0; i < dataNumber; i++)
            {
                base.Add(ContactGenerator.GenerateContact());
            }
        }
    }
}
