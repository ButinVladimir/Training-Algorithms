using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_5
{
    public static class BetweenTwoSets
    {
        public static int Solve(int[] a, int[] b)
        {
            int gcd = b[0];

            foreach (int number in b)
            {
                gcd = Gcd(number, gcd);
            }

            int result = 0;
            for (int factor = 1; factor <= gcd; factor++)
            {
                if (gcd % factor != 0)
                {
                    continue;
                }

                bool can = true;

                foreach (int number in a)
                {
                    if (factor % number > 0)
                    {
                        can = false;
                        break;
                    }
                }

                if (can)
                {
                    result++;
                }
            }

            return result;
        }

        private static int Gcd(int a, int b)
        {
            while (a > 0 && b > 0)
            {
                if (a > b)
                {
                    a = a % b;
                }
                else
                {
                    b = b % a;
                }
            }

            return a + b;
        }
    }
}
