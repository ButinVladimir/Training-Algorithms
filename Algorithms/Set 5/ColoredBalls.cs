using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_5
{
    public static class ColoredBalls
    {
        private const int N = 1001;
        private const long MOD = 1000000000 + 7;
        private static long[,] C = new long[N, N];

        static ColoredBalls()
        {
            for (int i = 0; i < N; i++)
            {
                C[i, 0] = 1;
            }

            for (int i = 1; i < N; i++)
            {
                for (int j = 1; j < N; j++)
                {
                    C[i, j] = (C[i - 1, j - 1] + C[i - 1, j]) % MOD;
                }
            }
        }

        public static long Solve(long[] c)
        {
            long sum = 0;
            for (int i = 0; i < c.Length; i++)
            {
                sum += c[i];
            }

            long result = 1;

            for (int i = c.Length - 1; i >= 0; i--)
            {
                sum--;
                c[i]--;

                result = (result * (C[sum, c[i]])) % MOD;
                sum -= c[i];
            }

            return result;
        }
    }
}
