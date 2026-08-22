using System.Globalization;
using System.Text;

namespace Nivaes.DataTestGenerator
{
    public static class ContactGenerator
    {
        #region Propeties
        /// <summary>List of personal name.</summary>
        private static readonly Tuple<string, double>[] givenNames = ReadNames(ResourceNames.GivenName);

        /// <summary>List of family name.</summary>
        private static readonly Tuple<string, double>[] familyNames = ReadNames(ResourceNames.FamilyName);

        /// <summary>List of email domain.</summary>
        private static readonly Tuple<string, double>[] emailDomains = [new Tuple<string, double>("mock.com", 0.4), new Tuple<string, double>("mock.es", 0.2), new Tuple<string, double>("mock.test.com", 0.2), new Tuple<string, double>("mock.test.es", 0.2)];
        #endregion

        /// <summary>Generate a contact.</summary>
        public static ContactTest GenerateContact()
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
        public static ContactTest GenerateExtenderContact()
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
        public static string GenerateName()
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

        private static string RandonTelephoneNumber()
        {
            StringBuilder sb = new StringBuilder();
            _ = sb.Append('6');
            for (int i = 0; i < 8; i++)
            {
                int ran = Random.Shared.Next(0, 9);
                sb.Append(ran.ToString(CultureInfo.InvariantCulture));
            }

            return sb.ToString();
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

        private static string RamdonName(Tuple<string, double>[] names)
        {
            double ran = Random.Shared.NextDouble();

            int i = 0, j = names.Length - 1;

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
