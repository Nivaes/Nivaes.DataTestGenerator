namespace Nivaes.DataTestGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Text;

    public abstract class BaseContactGenerator
    {
        #region Propeties
        /// <summary>Reference to <see cref="Random"/>.</summary>
        protected Random Random { get; }= new Random(DateTime.Now.Second * DateTime.Now.Millisecond);

        /// <summary>List of personal name.</summary>
        private readonly Tuple<string, double>[] mPersonalNames;

        /// <summary>List of family name.</summary>
        private readonly Tuple<string, double>[] mFamilyNames;

        /// <summary>List of email domain.</summary>
        private readonly Tuple<string, double>[] mEmailDomains;
        #endregion

        #region Constructor
        /// <summary>Static constructor of <see cref="BaseContactGenerator"/>.</summary>
        protected BaseContactGenerator()
        {
            mPersonalNames = ReadNames(ResourceNames.FirstName);
            mFamilyNames = ReadNames(ResourceNames.SecondName);

            mEmailDomains = new Tuple<string, double>[] { new Tuple<string, double>("mock.com", 0.4), new Tuple<string, double>("mock.es", 0.2), new Tuple<string, double>("mock.test.com", 0.2), new Tuple<string, double>("mock.test.es", 0.2) };
        }

        /// <summary>Read first name.</summary>
        private static Tuple<string, double>[] ReadNames(string fileNames)
        {
            using var sr = new StringReader(fileNames);
            List<Tuple<string, double>> names = new List<Tuple<string, double>>();
            string? line;
            double n = 0;
            while ((line = sr.ReadLine()) != null)
            {
                string[] values = line.Split(';');

                double p = double.Parse(values[1], CultureInfo.InvariantCulture);
                n += p;
                names.Add(Tuple.Create(values[0], p));
            }

            List<Tuple<string, double>> namesContinum = new List<Tuple<string, double>>();
            double j = 0;
            foreach (var name in names)
            {
                j += name.Item2;
                namesContinum.Add(new Tuple<string, double>(name.Item1, j / n));
            }

            return namesContinum.ToArray();
        }
        #endregion

        #region Methods
        /// <summary>Generate a contact.</summary>
        [SuppressMessage("Globalization", "CA1308:Normalize strings to uppercase", Justification = "Is a name.")]
        public ContactTest GenerateContact()
        {
            string personalName = RamdonName(mPersonalNames);
            string familyName1 = RamdonName(mFamilyNames);
            string familyName2 = RamdonName(mFamilyNames);
            string mailDomain = RamdonName(mEmailDomains);
            string sortName = ReduceFirstName(personalName.Replace(" ", string.Empty).RemovingAccents().ToLowerInvariant()) + familyName1.Replace(" ", string.Empty).RemovingAccents().ToLowerInvariant();

            return new ContactTest
            {
                SortName = sortName,
                LongName = $"{personalName} {familyName1} {familyName2}",
                PersonalName = personalName,
                FamilyName = $"{familyName1} {familyName2}",
                Email = $"{sortName}@{mailDomain}",
                TelephoneNumber = RandonTelephoneNumber()
            };
        }

        /// <summary>Generate a contact.</summary>
        [SuppressMessage("Globalization", "CA1308:Normalize strings to uppercase", Justification = "Is a name.")]
        public ContactTest GenerateExtenderContact()
        {
            string personalName = RamdonName(mPersonalNames);
            string familyName1 = RamdonName(mFamilyNames);
            string familyName2 = RamdonName(mFamilyNames);
            string mailDomain = RamdonName(mEmailDomains);
            string sortName = ReduceFirstName(personalName.Replace(" ", string.Empty).RemovingAccents().ToLowerInvariant()) + familyName1.Replace(" ", string.Empty).RemovingAccents().ToLowerInvariant();
            var mailName = personalName.Replace(" ", string.Empty).RemovingAccents().ToLowerInvariant()
                + "." + familyName1.Replace(" ", string.Empty).RemovingAccents().ToLowerInvariant()
                + "_" + familyName1.Replace(" ", string.Empty).RemovingAccents().ToLowerInvariant()
                + "_" + Random.Next(999999).ToString("000000", CultureInfo.InvariantCulture);

            return new ContactTest
            {
                SortName = sortName,
                LongName = $"{personalName} {familyName1} {familyName2}",
                PersonalName = personalName,
                FamilyName = $"{familyName1} {familyName2}",
                Email = $"{mailName}@{mailDomain}",
                TelephoneNumber = RandonTelephoneNumber()
            };
        }

        /// <summary>Generate a name.</summary>
        public string GenerateName()
        {
            string personalName = RamdonName(mPersonalNames);
            string familyName1 = RamdonName(mFamilyNames);
            string familyName2 = RamdonName(mFamilyNames);

            return string.Format(CultureInfo.CurrentCulture, $"{personalName} {familyName1} {familyName2}");
        }

        [SuppressMessage("Globalization", "CA1308:Normalize strings to uppercase", Justification = "Is a name.")]
        [SuppressMessage("Performance", "CA1822:Mark members as static")]
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
            _ = sb.Append('6');
            for(int i = 0; i < 8; i++)
            {
                int ran = Random.Next(0, 9);
                sb.Append(ran.ToString(CultureInfo.InvariantCulture));
            }

            return sb.ToString();
        }
        #endregion
    }
}
