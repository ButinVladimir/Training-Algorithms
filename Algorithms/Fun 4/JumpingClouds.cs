using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_4
{
    public static class JumpingClouds
    {
        public static int Solve(int[] a)
        {
            int n = a.Length;
            int[] values = new int[n];

            for (int i = 0; i < n; i++)
            {
                values[i] = n + 10;
            }
            values[0] = 0;

            for (int i = 1; i < n; i++)
            {
                if (a[i] == 0 && a[i - 1] == 0)
                {
                    values[i] = Math.Min(values[i], values[i - 1] + 1);
                }

                if (a[i] == 0 && i > 1 && a[i - 2] == 0)
                {
                    values[i] = Math.Min(values[i], values[i - 2] + 1);
                }
            }

            return values[n - 1];
        }
    }
}
