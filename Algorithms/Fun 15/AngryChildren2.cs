using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Fun_15
{
    public static class AngryChildren2
    {
        public static long Solve(int k, long[] a)
        {
            Array.Sort(a);
            long[] sum = new long[a.Length];

            sum[0] = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                sum[i] = sum[i - 1] + a[i];
            }

            long accumulatedSum = 0;
            for (int i = 0; i < k; i++)
            {
                accumulatedSum += i * a[i] - GetSum(0, i - 1, sum);
            }

            long result = accumulatedSum;
            for (int i = k; i < a.Length; i++)
            {
                accumulatedSum += k * a[i] - GetSum(i - k, i - 1, sum);
                accumulatedSum -= GetSum(i - k + 1, i, sum) - k * a[i - k];

                result = Math.Min(result, accumulatedSum);
            }

            return result;
        }

        private static long GetSum(int left, int right, long[] sum)
        {
            if (right < 0)
            {
                return 0;
            }

            if (left > 0)
            {
                return sum[right] - sum[left - 1];
            }

            return sum[right];
        }
    }
}
