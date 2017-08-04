using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_15
{
    public static class Castle
    {
        public static long Solve(int n)
        {
            long[] a = new long[n + 1];
            a[0] = 1;
            for (int i = 1; i <= n; i++)
            {
                a[i] = 0;

                for (int j = 1; j <= i; j += 2)
                {
                    a[i] += a[i - j];
                }
            }

            return a[n];
        }
    }
}
