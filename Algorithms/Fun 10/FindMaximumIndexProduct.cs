using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_10
{
    public static class FindMaximumIndexProduct
    {
        public static long Solve(long[] a)
        {
            int n = a.Length;
            long[] left = new long[n];
            long[] right = new long[n];

            left[0] = -1;
            for (int i = 1; i < n; i++)
            {
                left[i] = i - 1;
                while (left[i] != -1 && a[left[i]] <= a[i])
                {
                    left[i] = left[left[i]];
                }
            }

            right[n - 1] = -1;
            for (int i = n - 2; i >= 0; i--)
            {
                right[i] = i + 1;
                while (right[i] != -1 && a[right[i]] <= a[i])
                {
                    right[i] = right[right[i]];
                }
            }

            long result = (left[0] + 1) * (right[0] + 1);
            for (int i = 0; i < n; i++)
            {
                result = Math.Max(result, (left[i] + 1) * (right[i] + 1));
            }

            return result;
        }
    }
}
