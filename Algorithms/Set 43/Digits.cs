using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_43
{
    class Digits
    {
        public static string Solve(string str)
        {
            Dictionary<char, int> charCounts = InitDict();

            for (int i = 0; i < str.Length; i++)
            {
                charCounts[str[i]]++;
            }

            int[] digitCounts = new int[10];
            Determine(digitCounts, charCounts, 0, 'Z', "ZERO");
            Determine(digitCounts, charCounts, 2, 'W', "TWO");
            Determine(digitCounts, charCounts, 4, 'U', "FOUR");
            Determine(digitCounts, charCounts, 6, 'X', "SIX");
            Determine(digitCounts, charCounts, 8, 'G', "EIGHT");
            Determine(digitCounts, charCounts, 5, 'F', "FIVE");
            Determine(digitCounts, charCounts, 7, 'V', "SEVN");
            Determine(digitCounts, charCounts, 3, 'R', "THRE");
            Determine(digitCounts, charCounts, 1, 'O', "ONE");
            Determine(digitCounts, charCounts, 9, 'I', "NIE");

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                sb.Append(Convert.ToChar('0' + i), digitCounts[i]);
            }

            return sb.ToString();
        }

        private static Dictionary<char, int> InitDict()
        {
            Dictionary<char, int> result = new Dictionary<char, int>();

            for (char c = 'A'; c <= 'Z'; c++)
            {
                result[c] = 0;
            }

            return result;
        }

        private static void Determine(int[] digitCounts, Dictionary<char, int> charCounts, int digit, char c, string letters)
        {
            int count = charCounts[c];
            digitCounts[digit] += count;

            for (int i = 0; i < letters.Length; i++)
            {
                charCounts[letters[i]] -= count;
            }
        }
    }
}
