using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_73
{
    public static class SumXor
    {
        public static long Solve(long n)
        {
            int result = 0;

            while (n > 0)
            {
                if (n % 2 == 0)
                {
                    result++;
                }

                n /= 2;
            }

            return (1L << result);
        }
    }
}
