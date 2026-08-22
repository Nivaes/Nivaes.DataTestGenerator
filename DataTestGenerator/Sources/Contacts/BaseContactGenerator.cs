using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace Nivaes.DataTestGenerator
{
    public abstract class BaseContactGenerator
    {
        #region Propeties
        /// <summary>List of personal name.</summary>
        private readonly Tuple<string, double>[] givenNames;

        /// <summary>List of family name.</summary>
        private readonly Tuple<string, double>[] familyNames;

        /// <summary>List of email domain.</summary>
        private readonly Tuple<string, double>[] emailDomains;
        #endregion

        #region Constructor
        /// <summary>Static constructor of <see cref="BaseContactGenerator"/>.</summary>
        protected BaseContactGenerator()
        {
            givenNames = ReadNames(ResourceNames.GivenName);
            familyNames = ReadNames(ResourceNames.FamilyName);

            emailDomains = new Tuple<string, double>[] { new Tuple<string, double>("mock.com", 0.4), new Tuple<string, double>("mock.es", 0.2), new Tuple<string, double>("mock.test.com", 0.2), new Tuple<string, double>("mock.test.es", 0.2) };
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
        public ContactTest GenerateContact()
        {
            string givenName = RamdonName(givenNames);
            string familyName1 = RamdonName(familyNames);
            string familyName2 = RamdonName(familyNames);
            string mailDomain = RamdonName(emailDomains);
            string sortName = ReduceFirstName(givenName.Replace(" ", string.Empty).RemovingAccents().ToLowerInvariant()) + familyName1.Replace(" ", string.Empty).RemovingAccents().ToLowerInvariant();

            return new ContactTest
            {
                SortName = sortName,
                LongName = $"{givenName} {familyName1} {familyName2}",
                GivenName = givenName,
                FamilyName = $"{familyName1} {familyName2}",
                Email = $"{sortName}@{mailDomain}",
                TelephoneNumber = RandonTelephoneNumber()
            };
        }

        /// <summary>Generate a contact.</summary>
        [SuppressMessage("Globalization", "CA1308:Normalize strings to uppercase", Justification = "Is a name.")]
        public ContactTest GenerateExtenderContact()
        {
            string givenName = RamdonName(givenNames);
            string familyName1 = RamdonName(familyNames);
            string familyName2 = RamdonName(familyNames);
            string mailDomain = RamdonName(emailDomains);
            string sortName = ReduceFirstName(givenName.Replace(" ", string.Empty).RemovingAccents().ToLowerInvariant()) + familyName1.Replace(" ", string.Empty).RemovingAccents().ToLowerInvariant();
            var mailName = givenName.Replace(" ", string.Empty).RemovingAccents().ToLowerInvariant()
                + "." + familyName1.Replace(" ", string.Empty).RemovingAccents().ToLowerInvariant()
                + "_" + familyName1.Replace(" ", string.Empty).RemovingAccents().ToLowerInvariant()
                + "_" + Random.Shared.Next(999999).ToString("000000", CultureInfo.InvariantCulture);

            return new ContactTest
            {
                SortName = sortName,
                LongName = $"{givenName} {familyName1} {familyName2}",
                GivenName = givenName,
                FamilyName = $"{familyName1} {familyName2}",
                Email = $"{mailName}@{mailDomain}",
                TelephoneNumber = RandonTelephoneNumber()
            };
        }

        /// <summary>Generate a name.</summary>
        public string GenerateName()
        {
            string gibenName = RamdonName(givenNames);
            string familyName1 = RamdonName(familyNames);
            string familyName2 = RamdonName(familyNames);

            return string.Format(CultureInfo.CurrentCulture, $"{gibenName} {familyName1} {familyName2}");
        }

        private static string ReduceFirstName(string gibenName)
        {
            ArgumentNullException.ThrowIfNull(gibenName);

            var reduceName = new StringBuilder();
            string[] fn = gibenName.Split(' ');
            foreach (string f in fn)
            {
                reduceName.Append(f[..1]);
            }

            return reduceName.ToString().ToLowerInvariant();
        }

        protected abstract string RamdonName(Tuple<string, double>[] names);

        private static string RandonTelephoneNumber()
        {
            StringBuilder sb = new StringBuilder();
            _ = sb.Append('6');
            for(int i = 0; i < 8; i++)
            {
                int ran = Random.Shared.Next(0, 9);
                sb.Append(ran.ToString(CultureInfo.InvariantCulture));
            }

            return sb.ToString();
        }
        #endregion
    }
}
