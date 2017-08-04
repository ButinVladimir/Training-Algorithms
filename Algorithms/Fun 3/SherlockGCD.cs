using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_3
{
    public static class SherlockGCD
    {
        public static bool Solve(int[] a)
        {
            int result = a[0];
            for (int i = 0; i < a.Length; i++)
            {
                result = GCD(a[i], result);
            }

            return result == 1;
        }

        private static int GCD(int a, int b)
        {
            while (a > 0 && b > 0)
            {
                if (b > a)
                {
                    b = b % a;
                }
                else
                {
                    a = a % b;
                }
            }

            return a + b;
        }
    }
}
