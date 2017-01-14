using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_58
{
    class Duplicate
    {
        public static int SolveArbitrary(int[] a)
        {
            int n = a.Length;
            int[] sorted = new int[n];
            a.CopyTo(sorted, 0);
            Array.Sort(a);

            for (int i = 1; i < n; i++)
            {
                if (a[i] == a[i - 1])
                {
                    return a[i];
                }
            }

            return -1;
        }

        public static int SolveMPlusOne(int[] a)
        {
            int sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i];
            }

            int m = a.Length - 1;
            return sum - m * (1 + m) / 2;
        }
    }
}
