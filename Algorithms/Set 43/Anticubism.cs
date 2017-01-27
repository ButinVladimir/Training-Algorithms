using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_43
{
    class Anticubism
    {
        public static long Solve(long[] a)
        {
            long sum = 0;
            long max = a[0];
            int n = a.Length;

            for (int i = 0; i < n; i++)
            {
                sum += a[i];
                max = Math.Max(a[i], max);
            }

            return Math.Max(max - (sum - max) + 1, 1);
        }
    }
}
