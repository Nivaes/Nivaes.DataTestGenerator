namespace Nivaes.DataTestGenerator
{
    using System;
    using System.Globalization;
    using System.Text;

    internal static class StringExtensions
    {
        public static string RemovingAccents(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            string normalizedString = text.Normalize(NormalizationForm.FormD);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < normalizedString.Length; i++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(normalizedString[i]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(normalizedString[i]);
                }
            }
            return (sb.ToString());
        }
    }
}
