using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_5
{
    public static class SamSubStrings
    {
        private const long Mod = 1000000000 + 7;

        public static long Solve(string number)
        {
            long result = 0;
            long power10 = 1;
            long sum10 = 1;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                int digit = number[i] - '0';
                result = (result + (i + 1) * sum10 % Mod * digit % Mod) % Mod;
                power10 = power10 * 10 % Mod;
                sum10 = (sum10 + power10) % Mod;
            }

            return result;
        }
    }
}
