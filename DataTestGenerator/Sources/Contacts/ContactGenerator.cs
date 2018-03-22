namespace Nivaes.DataTestGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using Nivaes.DataTestGenerator.Resources;

    public static class NameGenerator
    {
        #region Propeties
        /// <summary>Reference to <see cref="Random"/>.</summary>
        private static Random mRandom;

        /// <summary>List of first name.</summary>
        private static Tuple<string, double>[] mFirstNames;

        /// <summary>List of second name.</summary>
        private static Tuple<string, double>[] mSecondNames;

        /// <summary>List of email domain.</summary>
        private static Tuple<string, double>[] mEmailDomains;
        #endregion

        #region Constructor
        /// <summary>Static constructor of <see cref="NameGenerator"/>.</summary>
        static NameGenerator()
        {
            mRandom = new Random(DateTime.Now.Millisecond);
            mFirstNames = ReadNames(ResourceNames.FirstName);
            mSecondNames = ReadNames(ResourceNames.SecondName);

            mEmailDomains = new Tuple<string, double>[] { new Tuple<string, double>("gmail.com", 4), new Tuple<string, double>("outlook.com", 1), new Tuple<string, double>("hotmail.com", 1), new Tuple<string, double>("hotmail.es", 1) };
        }

        /// <summary>Read first name.</summary>
        private static Tuple<string, double>[] ReadNames(string fileNames)
        {
            using (var sr = new StringReader(fileNames))
            {
                List<Tuple<string, double>> names = new List<Tuple<string, double>>();
                string line;
                double n = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] values = line.Split(';');

                    double p = double.Parse(values[1], CultureInfo.InvariantCulture);
                    n += p; 
                    names.Add(Tuple.Create(values[0], p));
                }

                List<Tuple<string, double>> namesContinum = new List<Tuple<string, double>>();
                double j=0;
                foreach(var name in names)
                {
                    j += name.Item2;
                    namesContinum.Add(new Tuple<string, double>(name.Item1,  j / n));
                }

                return namesContinum.ToArray();
            }
        }
        #endregion

        #region Methods
        /// <summary>Generate a contact.</summary>
        public static Contact GenerateContact()
        {
            string firstName = RamdonName(mFirstNames);
            string secondName1 = RamdonName(mSecondNames);
            string secondName2 = RamdonName(mSecondNames);
            string mailDomainRan = RamdonName(mEmailDomains);

            return new Contact
            {
                SortName = firstName,
                LongName = $"{firstName} {secondName1} {secondName2}",
                FirstName = firstName,
                SecondName = $"{secondName1} {secondName2}",
                Email = "{sortName}@{mailDomainRan}",
                TelephoneNumber = RandonTelephoneNumber()
            };
        }

        /// <summary>Generate a name.</summary>
        public static string GenerateName()
        {
            string firstName = RamdonName(mFirstNames);
            string secondName1 = RamdonName(mSecondNames);
            string secondName2 = RamdonName(mSecondNames);

            return string.Format(CultureInfo.CurrentCulture, "{0} {1} {2}", firstName, secondName1, secondName2);
        }

        private static string ReduceFirstName(string firstName)
        {
            string reduceName = string.Empty;
            string[] fn = firstName.Split(' ');
            foreach (string f in fn)
            {
                reduceName += f.Substring(0, 1);
            }

            return reduceName.ToLowerInvariant();
        }

        private static string RamdonName(Tuple<string, double>[] names)
        {
            double ran = mRandom.NextDouble();

            int i = 0, j = names.Length;

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

        private static string RandonTelephoneNumber()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("6");
            for(int i = 0; i < 8; i++)
            {
                int ran = mRandom.Next(0, 9);
                sb.Append(ran.ToString());
            }

            return sb.ToString();
        }
        #endregion
    }
}
