using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Set_64
{
    class Chosen
    {
        public static long Solve(int n, long[] numbers)
        {
            if (n == 1)
            {
                return numbers[0] + 1;
            }

            long commonGCD = numbers[0];
            for (int i = 1; i < n; i++)
            {
                commonGCD = GCD(commonGCD, numbers[i]);
            }

            for (int i = 0; i < n; i++)
            {
                numbers[i] /= commonGCD;
            }

            long[] prefix = new long[n];
            prefix[0] = numbers[0];

            for (int i = 1; i < n; i++)
            {
                prefix[i] = GCD(numbers[i], prefix[i - 1]);
            }

            long[] suffix = new long[n];
            suffix[n-1] = numbers[n-1];

            for (int i = n - 2; i >= 0; i--)
            {
                suffix[i] = GCD(numbers[i], suffix[i + 1]);
            }

            long exceptGCD;
            for (int i = 1; i < n - 1; i++)
            {
                exceptGCD = GCD(prefix[i - 1], suffix[i + 1]);
                if (exceptGCD != 1)
                {
                    return commonGCD * exceptGCD;                    
                }
            }

            if (prefix[n - 2] != 1)
            {
                return commonGCD * prefix[n - 2];
            }

            if (suffix[1] != 1)
            {
                return commonGCD * suffix[1];
            }

            return commonGCD;
        }

        private static long GCD(long a, long b)
        {
            long c;
            while (a != 0 && b != 0)
            {
                if (a < b)
                {
                    c = a;
                    a = b;
                    b = c;
                }

                a = a % b;
            }

            return a + b;
        }
    }
}
