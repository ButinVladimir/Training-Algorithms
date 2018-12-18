using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_12
{
    public static class MaxMin
    {
        public static long Solve(int k, long[] a)
        {
            Array.Sort(a);
            long result = long.MaxValue;
            for (int i = k - 1; i < a.Length; i++)
            {
                result = Math.Min(result, a[i] - a[i - k + 1]);
            }

            return result;
        }
    }
}
