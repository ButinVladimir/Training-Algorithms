using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_4
{
    public static class RepeatedString
    {
        public static long Solve(string s, long n)
        {
            long result = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'a')
                {
                    result++;
                }
            }

            result *= n / s.Length;

            n %= s.Length;

            for (int i = 0; i < n; i++)
            {
                if (s[i] == 'a')
                {
                    result++;
                }
            }

            return result;
        }
    }
}
