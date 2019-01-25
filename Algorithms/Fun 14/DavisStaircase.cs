using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_14
{
    public static class DavisStaircase
    {
        private const int N = 37;
        private const long Mod = 10000000000 + 7;
        private static long[] answers;

        static DavisStaircase()
        {
            answers = new long[N];
            answers[0] = 1;
            for (int i = 1; i < N; i++)
            {
                for (int j = 1; j <= 3 && i - j >= 0; j++)
                {
                    answers[i] = (answers[i] + answers[i - j]) % Mod;
                }
            }
        }

        public static long Solve(int n)
        {
            return answers[n];
        }
    }
}
