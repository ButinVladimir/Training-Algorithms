using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_2
{
    public static class CaesarCipher
    {
        public static string Solve(string s, int k)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(s);

            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLower(s[i]))
                {
                    sb[i] = (char)('a' + ((int)(s[i] - 'a') + k) % 26);
                }

                if (char.IsUpper(s[i]))
                {
                    sb[i] = (char)('A' + ((int)(s[i] - 'A') + k) % 26);
                }
            }

            return sb.ToString();
        }
    }
}
