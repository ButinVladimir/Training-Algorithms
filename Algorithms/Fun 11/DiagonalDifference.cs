using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_11
{
    public static class DiagonalDifference
    {
        public static long Solve(int n, int[,] a)
        {
            long result = 0;
            for (int i = 0; i < n; i++)
            {
                result += a[i, i] - a[n - 1 - i, i];
            }

            return Math.Abs(result);
        }
    }
}
