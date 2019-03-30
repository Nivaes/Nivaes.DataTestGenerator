namespace Nivaes.DataTestGenerator
{
    using System;

    public sealed class ContactProporcionalGenerator
        : BaseContactGenerator
    {
        private ContactProporcionalGenerator()
        { }

        private static ContactProporcionalGenerator mContactProporcionalGenerator;

        public static ContactProporcionalGenerator Instance
        {
            get
            {
                if (mContactProporcionalGenerator == null)
                    mContactProporcionalGenerator = new ContactProporcionalGenerator();

                return mContactProporcionalGenerator;
            }
        }

        protected override string RamdonName(Tuple<string, double>[] names)
        {
            double ran = base.Random.NextDouble();

            int i = 0, j = names.Length-1;

            while (true)
            {
                int n = (i + j) / 2;

                double d = names[n].Item2;
                if (d > ran)
                    j = n;
                else
                    i = n;

                if (j - i <= 1)
                {
                    if (names[i].Item2 < ran)
                        return names[j].Item1;
                    else
                        return names[i].Item1;
                }
            }
        }
    }
}
