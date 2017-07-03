using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_72
{
    public static class Xor
    {
        public static long Solve(long l, long r)
        {
            return Solve(r) ^ Solve(l - 1);
        }

        private static long Solve(long n)
        {
            if (n == 0)
            {
                return 0;
            }

            long result = 0;
            if (n % 4 == 1)
            {
                result ^= 1;
            }

            if (n % 8 >= 2 && n % 8 <= 5)
            {
                result ^= 2;
            }

            long m = 2;
            long m2;
            long mod;
            for (long i = 0; i < 50; i++)
            {
                m *= 2;
                m2 = m * 2;

                mod = n % m2;
                if (mod >= m && ((mod - m) / 2) % 2 == 0)
                {
                    result ^= m;
                }
            }

            return result;
        }
    }
}
