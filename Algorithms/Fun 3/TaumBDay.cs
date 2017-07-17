using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_3
{
    public static class TaumBDay
    {
        public static long Solve(long b, long w, long x, long y, long z)
        {
            return b * Math.Min(x, y + z) + w * Math.Min(y, x + z);
        }
    }
}
