using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun
{
    class Flipping
    {
        public static long Solve(int n, long[,] a)
        {
            long result = 0;
            long buffer;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    buffer = a[i, j];
                    buffer = Math.Max(buffer, a[2 * n - 1 - i, j]);
                    buffer = Math.Max(buffer, a[2 * n - 1 - i, 2 * n - 1 - j]);
                    buffer = Math.Max(buffer, a[i, 2 * n - 1 - j]);

                    result += buffer;
                }
            }

            return result;
        }
    }
}
