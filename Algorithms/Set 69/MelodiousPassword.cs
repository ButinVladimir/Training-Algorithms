using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_69
{
    public class MelodiousPassword
    {
        private static readonly char[] vowels = { 'e', 'u', 'i', 'o', 'a' };
        private static readonly char[] consonants = { 'q', 'w', 'r', 't', 'p', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm' };

        public static string[] Solve(int n)
        {
            List<string> result = new List<string>();
            StringBuilder sb = new StringBuilder();

            FillList(n, false, sb, result);
            FillList(n, true, sb, result);
            return result.ToArray();
        }

        private static void FillList(int n, bool vowel, StringBuilder sb, List<string> result)
        {
            if (n == 0)
            {
                result.Add(sb.ToString());
                return;
            }

            char[] letters = vowel ? vowels : consonants;

            for (int i = 0; i < letters.Length; i++)
            {
                sb.Append(letters[i]);
                FillList(n - 1, !vowel, sb, result);
                sb.Remove(sb.Length - 1, 1);
            }
        }
    }
}
