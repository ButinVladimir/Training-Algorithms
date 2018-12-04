using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_11
{
    public static class PlusMinus
    {
        public static decimal[] Solve(int[] a)
        {
            decimal[] count = new decimal[3];
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > 0)
                {
                    count[0]++;
                }
                else if (a[i] < 0)
                {
                    count[1]++;
                }
                else
                {
                    count[2]++;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                count[i] /= a.Length;
            }

            return count;
        }
    }
}
