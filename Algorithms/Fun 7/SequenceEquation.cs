using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_7
{
    public static class SequenceEquation
    {
        public static int[] Solve(int[] a)
        {
            int[] p = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                p[a[i] - 1] = i;
            }

            int[] result = new int[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                result[i] = p[p[i]] + 1;
            }

            return result;
        }
    }
}
