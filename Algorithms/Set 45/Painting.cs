using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_45
{
    class Painting
    {
        public static long Solve(long n, long[] a)
        {
            long sum = a[0] + a[1];
            long min = sum;
            long max = sum;

            Update(a, 0, 1, ref min, ref max);
            Update(a, 0, 2, ref min, ref max);
            Update(a, 3, 1, ref min, ref max);
            Update(a, 3, 2, ref min, ref max);

            long start = max - min + 1;
            if (start > n)
            {
                return 0;
            }

            return (n - start + 1) * n;
        }

        private static void Update(long[] a, int p1, int p2, ref long min, ref long max)
        {
            long sum = a[p1] + a[p2];

            min = Math.Min(min, sum);
            max = Math.Max(max, sum);
        }
    }
}
