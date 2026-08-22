namespace Nivaes.DataTestGenerator.Xunit
{
    public sealed class GenerateContactTheoryData
        : TheoryData<ContactTest>
    {
        public GenerateContactTheoryData()
        {
            base.Add(ContactProporcionalGenerator.Instance.GenerateContact());
        }

        public GenerateContactTheoryData(int dataNumber)
        {
            for (int i = 0; i < dataNumber; i++)
            {
                base.Add(ContactProporcionalGenerator.Instance.GenerateContact());
            }
        }
    }
}
