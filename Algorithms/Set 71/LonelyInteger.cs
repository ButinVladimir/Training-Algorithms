using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_71
{
    public static class LonelyInteger
    {
        public static int Solve(int[] a)
        {
            int result = 0;

            for (int i = 0; i < a.Length; i++)
            {
                result ^= a[i];
            }

            return result;
        }
    }
}
