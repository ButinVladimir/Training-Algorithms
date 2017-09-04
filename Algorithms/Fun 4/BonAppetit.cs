using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_4
{
    public static class BonAppetit
    {
        public static long Solve(long[] a, int k, long b)
        {
            long sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (i != k)
                {
                    sum += a[i];
                }
            }

            return b - sum / 2;
        }
    }
}
