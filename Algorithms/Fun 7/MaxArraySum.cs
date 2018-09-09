using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_7
{
    public static class MaxArraySum
    {
        public static long Solve(long[] a)
        {
            if (a.Length == 1)
            {
                return a[0];
            }

            long result = Math.Max(a[0], a[1]);
            long p2 = a[0];
            long p1 = a[1];
            long p;
            for (int i = 2; i < a.Length; i++)
            {
                p = Math.Max(a[i], Math.Max(a[i] + p2, p2));
                result = Math.Max(result, p);

                p2 = Math.Max(p2, p1);
                p1 = Math.Max(p1, p);
            }

            return result;
        }
    }
}
