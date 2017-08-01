using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_3
{
    public static class ChocolateFeast
    {
        public static long Solve(long n, long c, long m)
        {
            long result;
            long w = n / c;

            result = w;

            while (w >= m)
            {
                result += w / m;
                w = (w % m) + (w / m);
            }

            return result;
        }
    }
}
