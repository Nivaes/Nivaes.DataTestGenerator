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

        private char[][] mCharacterSet = new char[][]
             {
                "abcdefgijkmnopqrstwxyz".ToCharArray(),
                "ABCDEFGHJKLMNPQRSTWXYZ".ToCharArray(),
                "23456789".ToCharArray(),
                "*$-+?_&=!%{}/".ToCharArray()
            };

        private static PasswordGenerator mPasswerdGenerator;

        public static PasswordGenerator Instance
        {
            get
            {
                if (mPasswerdGenerator == null)
                    mPasswerdGenerator = new PasswordGenerator();

                return mPasswerdGenerator;
            }
        }

        public string CreatePassword()
        {
            var length = mRandom.Next(7, 20);

            return CreatePassword(length);
        }

        public string CreatePassword(int length)
        {
            if(length == 0)
                length = mRandom.Next(7, 20);

            return CreatePassword(length, mCharacterSet);
        }

        public string CreatePassword(string characterSet)
        {
            var length = mRandom.Next(7, 20);

            return CreatePassword(length, new char[][] { characterSet.ToCharArray() });
        }

        public string CreatePassword(int length, string characterSet)
        {
            if(length == 0)
                length = mRandom.Next(7, 20);

            char[][] characterSetInt;

            if (string.IsNullOrEmpty(characterSet))
                characterSetInt = mCharacterSet;
            else
                characterSetInt = new char[][] { characterSet.ToCharArray() };

            return CreatePassword(length, characterSetInt);
        }

        public string CreatePassword(IEnumerable<IEnumerable<char>> characterSet)
        {
            var length = mRandom.Next(7, 20);

            return CreatePassword(length, characterSet.Select(i => i.ToArray()).ToArray());
        }

        public string CreatePassword(int length, IEnumerable<IEnumerable<char>> characterSet)
        {
            return CreatePassword(length, characterSet.Select(i => i.ToArray()).ToArray());
        }

        private string CreatePassword(int length, char[][] characterSets)
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
                return CreatePassword(length, characterSets);

            return res.ToString();
        }
    }
}
