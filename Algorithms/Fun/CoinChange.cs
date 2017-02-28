using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun
{
    class CoinChange
    {
        public static long Solve(int n, int m, int[] coins)
        {
            long[,] result = new long[n + 1, m + 1];

            result[0, 0] = 1;

            for (int i = 0; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    result[i, j] += result[i, j - 1];
                    if (i >= coins[j - 1])
                    {
                        result[i, j] += result[i - coins[j - 1], j];
                    }
                }
            }

            return result[n, m];
        }
    }
}
