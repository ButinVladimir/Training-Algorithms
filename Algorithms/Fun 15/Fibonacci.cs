using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_15
{
    public static class Fibonacci
    {
        public static long Iterative(int n)
        {
            if (n <= 1)
            {
                return 0;
            }

            long current = 1;
            long prev = 0;
            long buffer;

            for (int i = 2; i < n; i++)
            {
                buffer = current;
                current += prev;
                prev = buffer;
            }

            return current;
        }

        public static long Recursive(int n)
        {
            if (n <= 1)
            {
                return 0;
            }

            if (n == 2)
            {
                return 1;
            }

            return Recursive(n - 1) + Recursive(n - 2);
        }
    }
}
