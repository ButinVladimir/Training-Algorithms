using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_27
{
    public static class Gift
    {
        public static long Solve(long[] a, int n, int m)
        {
            long[] b = new long[m];
            for (int i = 0; i < n; i++)
            {
                b[a[i] - 1]++;
            }

            long result = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = i + 1; j < m; j++)
                {
                    result += b[i] * b[j];
                }
            }

            return result;
        }
    }
}
