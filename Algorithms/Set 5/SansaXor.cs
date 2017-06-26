using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_5
{
    public static class SansaXor
    {
        public static int Solve(int[] a)
        {
            int result = 0;
            long left = 1;
            long right = a.Length;

            for (int i = 0; i < a.Length; i++)
            {
                if ((left * right) % 2 == 1)
                {
                    result ^= a[i];
                }

                left++;
                right--;
            }

            return result;
        }
    }
}
