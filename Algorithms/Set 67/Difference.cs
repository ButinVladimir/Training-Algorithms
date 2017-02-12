using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_67
{
    class Difference
    {
        public static long Solve(long[] a)
        {
            Array.Sort(a);

            long diff = a[1] - a[0];
            long newDiff;

            for (int i = 1; i < a.Length; i++)
            {
                newDiff = a[i] - a[i - 1];
                if (newDiff < diff)
                {
                    diff = newDiff;
                }
            }

            return diff;
        }
    }
}
