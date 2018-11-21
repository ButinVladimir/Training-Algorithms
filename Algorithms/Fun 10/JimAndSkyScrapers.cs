using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_10
{
    public static class JimAndSkyScrapers
    {
        public static long Solve(int[] a)
        {
            int n = a.Length;
            int[] next = new int[n];
            next[0] = -1;
            for (int i = 1; i < n; i++)
            {
                next[i] = i - 1;
                while (next[i] != -1 && a[next[i]] < a[i])
                {
                    next[i] = next[next[i]];
                }
            }

            long result = 0;
            int prev;
            long[] count = new long[n];
            for (int i = 0; i < n; i++)
            {
                count[i] = 1;
                prev = next[i];
                if (prev != -1 && a[prev] == a[i])
                {
                    result += count[prev];
                    count[i] += count[prev];
                }
            }

            return result * 2;
        }
    }
}
