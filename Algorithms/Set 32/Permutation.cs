using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_32
{
    public class Permutation
    {
        public static int[] Solve(int n, int[,] comparison)
        {
            int[] result = new int[n];

            bool pred = false;
            for (int i = 0; i < n; i++)
            {
                result[i] = n;
            }

            int max;
            for (int i = 0; i < n; i++)
            {
                max = comparison[i, 0];
                for (int j = 0; j < n; j++)
                {
                    max = Math.Max(max, comparison[i, j]);
                }

                if (max == n - 1 && !pred || max != n - 1)
                {
                    result[i] = max;

                    if (max == n - 1)
                    {
                        pred = true;
                    }
                }
            }

            return result;
        }
    }
}
