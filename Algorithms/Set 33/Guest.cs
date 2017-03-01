using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_33
{
    public class Guest
    {
        public static long Solve(long n, long a, long b, long c)
        {
            if (b - c > a || n < b)
            {
                return n / a;
            }

            long result = 0;
            long buffer;

            if (n >= b)
            {
                buffer = (n - b) / (b - c);
                result += buffer;
                n -= buffer * (b - c);
            }

            while (n >= b)
            {
                buffer = n / b;
                result += buffer;
                n = n - buffer * (b - c);
            }

            return result + n / Math.Min(a, b);
        }
    }
}
