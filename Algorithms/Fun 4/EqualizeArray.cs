using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_4
{
    public static class EqualizeArray
    {
        public const int N = 101;

        public static int Solve(int[] a)
        {
            int[] count = new int[N];
            for (int i = 0; i < a.Length; i++)
            {
                count[a[i]]++;
            }

            int result = a.Length;

            for (int i = 0; i < N; i++)
            {
                result = Math.Min(result, a.Length - count[i]);
            }

            return result;
        }
    }
}
