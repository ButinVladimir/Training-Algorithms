using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_28
{
    public static class Hamming
    {
        public static long Distance(string a, string b)
        {
            int n = a.Length;
            long[] pref = new long[n];
            for (int i = 0; i < n; i++)
            {
                if (i > 0)
                {
                    pref[i] += pref[i - 1];
                }

                if (a[i] == '1')
                {
                    pref[i]++;
                }
            }

            int m = b.Length;
            int l, r;
            long result = 0;
            for (int i = 0; i < m; i++)
            {
                r = i - (n - 1);
                if (r >= 0)
                {
                    r = n - 1;
                }
                else
                {
                    r = n - 1 + r;
                }

                l = i + (n - 1);
                if (l <= m - 1)
                {
                    l = 0;
                }
                else
                {
                    l = l - m + 1;
                }

                result += GetSum(l, r, pref, b[i] == '1');
            }

            return result;
        }

        private static long GetSum(int l, int r, long[] pref, bool inv)
        {
            long result = pref[r];
            if (l > 0)
            {
                result -= pref[l - 1];
            }

            if (inv)
            {
                result = r - l + 1 - result;
            }

            return result;
        }
    }
}
