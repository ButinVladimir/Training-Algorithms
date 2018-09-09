using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_7
{
    public static class Anagram
    {
        private const int L = 256;

        public static int Solve(string s)
        {
            if (s.Length % 2 == 1)
            {
                return -1;
            }

            int[] cnt = new int[L];
            int d = s.Length / 2;
            for (int i = 0; i < d; i++)
            {
                cnt[s[i]]++;
            }

            for (int i = d; i < s.Length; i++)
            {
                cnt[s[i]]--;
            }

            int diff = 0;
            for (int i = 0; i < L; i++)
            {
                diff += Math.Abs(cnt[i]);
            }

            return diff / 2;
        }
    }
}
