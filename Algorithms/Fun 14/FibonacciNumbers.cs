using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_14
{
    public static class FibonacciNumbers
    {
        public static long Solve(int n)
        {
            long a = 0;
            long b = 1;
            for (int i=0;i<n;i++)
            {
                long c = a;
                a = b;
                b += c;
            }

            return a;
        }
    }
}
