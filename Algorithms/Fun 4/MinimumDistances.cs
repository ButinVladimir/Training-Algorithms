using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_4
{
    public static class MinimumDistances
    {
        public const int N = 1000000;

        public static int Solve(int[] a)
        {
            int[] values = new int[N];
            for (int i = 0; i < N; i++)
            {
                values[i] = -1;
            }

            int result = a.Length + 1;

            for (int i = 0; i < a.Length; i++)
            {
                if (values[a[i]] != -1)
                {
                    result = Math.Min(result, i - values[a[i]]);
                }

                values[a[i]] = i;
            }

            return result == a.Length + 1 ? -1 : result;
        }
    }
}
