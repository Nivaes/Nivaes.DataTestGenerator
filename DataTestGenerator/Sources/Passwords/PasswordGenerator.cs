namespace Nivaes.DataTestGenerator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public sealed class PasswordGenerator
    {
        /// <summary>Reference to <see cref="mRandom"/>.</summary>
        private Random mRandom { get; } = new Random(DateTime.Now.Second * DateTime.Now.Millisecond);

        private readonly char[][] mCharacterSet = new char[][]
             {
                "abcdefgijkmnopqrstwxyz".ToCharArray(),
                "ABCDEFGHJKLMNPQRSTWXYZ".ToCharArray(),
                "23456789".ToCharArray(),
                "*$-+?_&=!%{}/".ToCharArray()
            };

        private static PasswordGenerator? mPasswerdGenerator;

        public static PasswordGenerator Instance => mPasswerdGenerator ??= new PasswordGenerator();

        public string GeneratePassword()
        {
            var length = mRandom.Next(7, 20);

            return GeneratePassword(length);
        }

        public string GeneratePassword(int length)
        {
            if(length == 0)
                length = mRandom.Next(7, 20);

            return GeneratePassword(length, mCharacterSet);
        }

        public string GeneratePassword(string characterSet)
        {
            if (characterSet == null) throw new ArgumentNullException(nameof(characterSet));

            var length = mRandom.Next(7, 20);

            return GeneratePassword(length, new char[][] { characterSet.ToCharArray() });
        }

        public string GeneratePassword(int length, string? characterSet)
        {
            if(length == 0)
                length = mRandom.Next(7, 20);

            char[][] characterSetInt;

            if (string.IsNullOrEmpty(characterSet))
                characterSetInt = mCharacterSet;
            else
                characterSetInt = new char[][] { characterSet!.ToCharArray() };

            return GeneratePassword(length, characterSetInt);
        }

        public string GeneratePassword(IEnumerable<IEnumerable<char>> characterSet)
        {
            var length = mRandom.Next(7, 20);

            return GeneratePassword(length, characterSet.Select(i => i.ToArray()).ToArray());
        }

        public string GeneratePassword(int length, IEnumerable<IEnumerable<char>> characterSet)
        {
            return GeneratePassword(length, characterSet.Select(i => i.ToArray()).ToArray());
        }

        private string GeneratePassword(int length, char[][] characterSets)
        { 
            if (length <= 0)
                throw new ArgumentException("length must not be negative", nameof(length));
            if (length > int.MaxValue / 8)
                throw new ArgumentException("length is too big", nameof(length));
            if (characterSets == null)
                throw new ArgumentNullException(nameof(characterSets));
            if (characterSets.Length == 0)
                throw new ArgumentException("characterSets must not be empty", nameof(characterSets));
            if(characterSets.Any(c => c.Length == 0))
                throw new ArgumentException("characterSets must not be empty", nameof(characterSets));

            var characterSetUse = new BitArray(characterSets.Length);

            StringBuilder res = new StringBuilder();
            int n = length;
            while (0 < n--)
            {
                var characterSetsUser = mRandom.Next(characterSets.Length);
                var characterSet = characterSets[characterSetsUser];

                res.Append(characterSet[mRandom.Next(characterSet.Length)]);

                characterSetUse.Set(characterSetsUser, true);
            }

            if (characterSetUse.Cast<bool>().Any(b => !b))
                return GeneratePassword(length, characterSets);

            return res.ToString();
        }
    }
}
