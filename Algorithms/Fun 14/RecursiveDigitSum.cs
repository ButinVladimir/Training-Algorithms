using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_14
{
    public static class RecursiveDigitSum
    {
        public static long Solve(string n, long k)
        {
            long sum = 0;
            for (int i = 0; i < n.Length; i++)
            {
                sum += n[i] - '0';
            }

            sum *= k;

            long next;
            while (sum >= 10)
            {
                next = 0;
                while (sum > 0)
                {
                    next += sum % 10;
                    sum /= 10;
                }

                sum = next;
            }

            return sum;
        }
    }
}
