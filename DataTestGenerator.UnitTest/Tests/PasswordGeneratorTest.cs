namespace Nivaes.DataTestGenerator.UnitTest
{
    using System.Collections.Generic;
    using Shouldly;
    using Xunit;

    public class PasswordGeneratorTest
    {
        private readonly ITestOutputHelper mOutput;

        public PasswordGeneratorTest(ITestOutputHelper output)
        {
            mOutput = output;
        }

        [Fact]
        public void PasswordGeneratorString01()
        {
            var password = PasswordGenerator.Instance.GeneratePassword();
            mOutput.WriteLine(password);
            password.ShouldNotBeNullOrEmpty();
        }

        [Fact]
        public void PasswordGeneratorString02()
        {
            List<string> passwords = new();
            for (int i = 0; i < 100; i++)
            {
                var password = PasswordGenerator.Instance.GeneratePassword();

                password.ShouldNotBeNullOrEmpty();
                passwords.ShouldNotContain(password);

                passwords.Add(password);
                mOutput.WriteLine(password);
            }
        }
    }
}
