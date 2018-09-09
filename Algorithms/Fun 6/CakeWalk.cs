using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_6
{
    public static class CakeWalk
    {
        public static long Solve(long[] a)
        {
            Array.Sort(a);
            Array.Reverse(a);

            long mod = 1;
            long result = 0;

            for (int i = 0; i < a.Length; i++)
            {
                result += mod * a[i];
                mod *= 2L;
            }

            return result;
        }
    }
}
    