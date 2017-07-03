using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_72
{
    public static class Permuting
    {
        public static bool Solve(long[] a, long[] b, long k)
        {
            Array.Sort(a);
            Array.Sort(b);
            Array.Reverse(a);

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] + b[i] < k)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
