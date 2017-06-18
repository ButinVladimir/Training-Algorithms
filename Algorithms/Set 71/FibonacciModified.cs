using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_71
{
    public static class FibonacciModified
    {
        public static string Solve(int s1, int s2, int n)
        {
            BigInteger t1 = s1;
            BigInteger t2 = s2;

            n -= 2;
            for (int i=0;i<n;i++)
            {
                BigInteger t3 = t1 + t2 * t2;
                t1 = t2;
                t2 = t3;
            }

            return t2.ToString();
        }
    }
}
