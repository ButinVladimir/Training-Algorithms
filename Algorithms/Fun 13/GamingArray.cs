using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_13
{
    public static class GamingArray
    {
        public static bool Solve(int[] a)
        {
            int[] prev = new int[a.Length];
            prev[0] = 0;
            for (int i = 1; i < a.Length; i++)
            {
                prev[i] = prev[i - 1];
                if (a[i] > a[prev[i]])
                {
                    prev[i] = i;
                }
            }

            int count = 0;
            int pos = a.Length - 1;
            while (pos >= 0)
            {
                pos = prev[pos] - 1;
                count++;
            }

            return count % 2 == 1;
        }
    }
}
