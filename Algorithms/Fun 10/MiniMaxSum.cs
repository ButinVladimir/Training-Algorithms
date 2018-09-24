using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_10
{
    public static class MiniMaxSum
    {
        public static Tuple<long, long> Solve(long[] a)
        {
            long sum = a.Sum();
            long min = sum - a[0];
            long max = sum - a[0];
            long buf;

            for (int i = 0; i < a.Length; i++)
            {
                buf = sum - a[i];
                min = Math.Min(min, buf);
                max = Math.Max(max, buf);
            }

            return new Tuple<long, long>(min, max);
        }
    }
}
