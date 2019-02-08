using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_14
{
    public static class MandragoraForest
    {
        public static long Solve(long[] healths)
        {
            long result = 0;
            Array.Sort(healths);

            int n = healths.Length;
            long[] h = new long[n];
            for (int i = n - 1; i >= 0; i--)
            {
                h[i] = healths[i];
                if (i < n - 1)
                {
                    h[i] += h[i + 1];
                }
            }

            for (long s = 0; s < n; s++)
            {
                result = Math.Max(result, (s + 1) * h[s]);
            }

            return result;
        }
    }
}
