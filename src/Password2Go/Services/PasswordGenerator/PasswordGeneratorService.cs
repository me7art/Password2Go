using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password2Go.Services.PasswordGenerator
{
    public class PasswordGeneratorService
    {
        //
        // TODO: 
        // System.Security.Cryptography.RandomNumberGenerator 
        // using System.Security.Cryptography;
        // ...
        // RNGCryptoServiceProvider rnd = new RNGCryptoServiceProvider();
        // ...
        //

    Random rnd = new Random();

        public string GeneratePassword(int lowercase_count, int uppercase_count, int numbers_count, int special_count)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GeneratePart(LOWERCASE_ARRAY, lowercase_count));
            sb.Append(GeneratePart(UPPERCASE_ARRAY, uppercase_count));
            sb.Append(GeneratePart(NUMBERS_ARRAY, numbers_count));
            sb.Append(GeneratePart(SPECIALS_ARRAY, special_count));

            return new string(sb.ToString().OrderBy(x => rnd.Next()).ToArray());
        }

        private string GeneratePart(char[] charArray, int count)
        {
            if (count == 0)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();
            for (int n = 0; n < count; n++)
            {
                sb.Append(charArray[rnd.Next(0, charArray.Length)]);
            }

            return sb.ToString();
        }

        char[] LOWERCASE_ARRAY = "abcdefghijklmnopqestuvwxyz".ToCharArray();
        char[] UPPERCASE_ARRAY = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        char[] NUMBERS_ARRAY   = "0123456789".ToCharArray();
        char[] SPECIALS_ARRAY = "~!@#$%^&*()_+".ToCharArray();
    }
}
