using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_71
{
    public static class CounterGame
    {
        public static bool Solve(long n)
        {
            bool louiseWins = false;

            while (n > 1)
            {
                n -= FindDiff(n);
                louiseWins = !louiseWins;
            }

            return louiseWins;
        }

        public static long FindDiff(long n)
        {
            int digit = 0;
            while ((n & 1) == 0)
            {
                digit++;
                n >>= 1;
            }

            if (n == 1)
            {
                return 1L << (digit - 1);
            }

            while (n > 1)
            {
                digit++;
                n >>= 1;
            }

            return 1L << digit;
        }
    }
}
