using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_14
{
    public static class SpecialPalindrome
    {
        public static long Solve(string s)
        {
            int left = 0;
            long result = 0;
            while (left < s.Length)
            {
                int right = left;
                while (right < s.Length && s[left] == s[right])
                {
                    right++;
                }

                long d = right - left;
                result = result += d * (d + 1) / 2;
                left = right;
            }

            for (int i = 1; i < s.Length - 1; i++)
            {
                if (s[i] == s[i - 1] || s[i] == s[i + 1] || s[i - 1] != s[i + 1])
                {
                    continue;
                }

                int lc = i - 1;
                while (lc >= 0 && s[lc] == s[i - 1])
                {
                    lc--;
                }

                int rc = i + 1;
                while (rc < s.Length && s[rc] == s[i + 1])
                {
                    rc++;
                }

                result += Math.Min(rc - i - 1, i - lc - 1);
            }

            return result;
        }
    }
}
