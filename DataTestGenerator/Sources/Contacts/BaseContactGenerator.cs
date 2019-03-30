namespace Nivaes.DataTestGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using Nivaes.DataTestGenerator.Resources;

    public abstract class BaseContactGenerator
    {
        #region Propeties
        /// <summary>Reference to <see cref="Random"/>.</summary>
        protected Random Random { get; private set; }

        /// <summary>List of personal name.</summary>
        private readonly Tuple<string, double>[] mPersonalNames;

        /// <summary>List of family name.</summary>
        private readonly Tuple<string, double>[] mFamilyNames;

        /// <summary>List of email domain.</summary>
        private readonly Tuple<string, double>[] mEmailDomains;
        #endregion

        #region Constructor
        /// <summary>Static constructor of <see cref="ContactGenerator"/>.</summary>
        public BaseContactGenerator()
        {
            Random = new Random(DateTime.Now.Second * DateTime.Now.Millisecond);
            mPersonalNames = ReadNames(ResourceNames.FirstName);
            mFamilyNames = ReadNames(ResourceNames.SecondName);

            mEmailDomains = new Tuple<string, double>[] { new Tuple<string, double>("gmail.com", 0.4), new Tuple<string, double>("outlook.com", 0.2), new Tuple<string, double>("hotmail.com", 0.2), new Tuple<string, double>("hotmail.es", 0.2) };
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
        public Contact GenerateContact()
        {
            string personalName = RamdonName(mPersonalNames);
            string secondName1 = RamdonName(mFamilyNames);
            string secondName2 = RamdonName(mFamilyNames);
            string mailDomain = RamdonName(mEmailDomains);
            string sortName = ReduceFirstName(personalName.RemovingAccents().ToLowerInvariant()) + secondName1.Replace(" ", string.Empty).RemovingAccents().ToLowerInvariant();

            return new Contact
            {
                SortName = sortName,
                LongName = $"{personalName} {secondName1} {secondName2}",
                PersonalName = personalName,
                FamilyName = $"{secondName1} {secondName2}",
                Email = $"{sortName}@{mailDomain}",
                TelephoneNumber = RandonTelephoneNumber()
            };
        }

        /// <summary>Generate a contact.</summary>
        public Contact GenerateExtenderContact()
        {
            string PersonalName = RamdonName(mPersonalNames);
            string secondName1 = RamdonName(mFamilyNames);
            string secondName2 = RamdonName(mFamilyNames);
            string mailDomain = RamdonName(mEmailDomains);
            string sortName = ReduceFirstName(PersonalName.RemovingAccents().ToLowerInvariant()) + secondName1.Replace(" ", string.Empty).RemovingAccents().ToLowerInvariant();
            var mailName = PersonalName.RemovingAccents().ToLowerInvariant()
                + "." + secondName1.Replace(" ", string.Empty).RemovingAccents().ToLowerInvariant()
                + "_" + secondName1.Replace(" ", string.Empty).RemovingAccents().ToLowerInvariant()
                + "_" + Random.Next(999999).ToString("000000");

            return new Contact
            {
                SortName = sortName,
                LongName = $"{PersonalName} {secondName1} {secondName2}",
                PersonalName = PersonalName,
                FamilyName = $"{secondName1} {secondName2}",
                Email = $"{mailName}@{mailDomain}",
                TelephoneNumber = RandonTelephoneNumber()
            };
        }

        /// <summary>Generate a name.</summary>
        public string GenerateName()
        {
            string firstName = RamdonName(mPersonalNames);
            string secondName1 = RamdonName(mFamilyNames);
            string secondName2 = RamdonName(mFamilyNames);

            return string.Format(CultureInfo.CurrentCulture, $"{firstName} {secondName1} {secondName2}");
        }

        private string ReduceFirstName(string personalName)
        {
            string reduceName = string.Empty;
            string[] fn = personalName.Split(' ');
            foreach (string f in fn)
            {
                reduceName += f.Substring(0, 1);
            }

            return reduceName.ToLowerInvariant();
        }

        protected abstract string RamdonName(Tuple<string, double>[] names);

        private string RandonTelephoneNumber()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("6");
            for(int i = 0; i < 8; i++)
            {
                int ran = Random.Next(0, 9);
                sb.Append(ran.ToString());
            }

            return sb.ToString();
        }
        #endregion
    }
}
