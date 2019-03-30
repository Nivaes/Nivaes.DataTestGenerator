namespace Nivaes.DataTestGenerator
{
    using System;

    public sealed class ContactGenerator
        : BaseContactGenerator
    {
        private ContactGenerator()
        { }

        private static ContactGenerator mContactGenerator;

        public static ContactGenerator Instance
        {
            get
            {
                if (mContactGenerator == null)
                    mContactGenerator = new ContactGenerator();

                return mContactGenerator;
            }
        }

        protected override string RamdonName(Tuple<string, double>[] names)
        {
            double ran = base.Random.NextDouble();

            return names[(int)(ran * names.Length)].Item1;
        }
    }
}
