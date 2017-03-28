using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_28
{
    public static class Hotel
    {
        public static int Solve(int n, int s, int[] f, int[] t)
        {
            int[] maxes = new int[s + 1];
            for (int i = 0; i < n; i++)
            {
                maxes[f[i]] = Math.Max(maxes[f[i]], t[i]);
            }

            int result = maxes[s];
            while (s > 0)
            {
                result = Math.Max(result, maxes[s]) + 1;
                s--;
            }

            return result;
        }
    }
}
