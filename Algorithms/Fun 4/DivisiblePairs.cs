using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_4
{
    public static class DivisiblePairs
    {
        public static int Solve(int[] a, int k)
        {
            int result = 0;

            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if ((a[i] + a[j]) % k == 0)
                    {
                        result++;
                    }
                }
            }

            return result;
        }
    }
}
