using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_53
{
    class ZeroCount
    {
        public static long Solve(long n)
        {
            return Math.Min(Power(2, n), Power(5, n));
        }

        private static long Power(long b, long n)
        {
            long pwr = b;
            long result = 0;

            while (pwr <= n)
            {
                result += n / pwr;
                pwr *= b;
            }

            return result;
        }
    }
}
